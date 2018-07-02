using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GetOrganized.Data;
using GetOrganized.Models;
using GetOrganized.Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using GetOrganized.Persistence.GetOrganized.Web.Persistence;
using FluentNHibernate.Cfg.Db;
using System.IO;
using NHibernate.Tool.hbm2ddl;
using GetOrganized.Persistence;
using GetOrganized.Persistence.Repositories;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace GetOrganized
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly object lockObject = new object();
        private bool wasNHibernateInitialized;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<NHibernateSessionStorage, NHibernateSessionStorage>();
            //services.AddTransient(x => (NHibernate.ISession)x.GetRequiredService<NHibernateSessionStorage>().RetrieveSession());
            services.AddScoped( x => NHibernateConfiguration.CreateAndOpenSession());
            //services.AddTransient<TodoRepository, TodoRepository>();
            services.AddScoped<TransactionAttribute>();

            IEnumerable<Type> repositories = Assembly.GetExecutingAssembly().GetTypes().Where(IsRepository);
            foreach (Type type in repositories)
            {
                services.AddTransient(type, type);
            }

            services.AddMvc(options => { options.UseHtmlEncodeModelBinding(); });
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddSession();
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            InitializeNHibernate();
        }

        private bool IsRepository(Type type)
        {
            return type.Namespace != null && type.IsClass && !type.IsAbstract && type.Namespace.Contains("GetOrganized.Persistence.Repositories");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSessionMiddleware();
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }


        private void InitializeNHibernate()
        {
            if (!wasNHibernateInitialized)
            {
                lock (lockObject)
                {
                    if (!wasNHibernateInitialized)
                    {
                        NHibernateConfiguration.Init(
                            SQLiteConfiguration.Standard.UsingFile("test_GetOrganized"),
                            //MsSqlConfiguration.MsSql2008.ConnectionString(
                            //builder => builder.Server("localhost").Database("test_GetOrganized").TrustedConnection()),
                            RebuildDatabase
                            );

                        wasNHibernateInitialized = true;
                    }
                }
            }
        }

        private void RebuildDatabase(NHibernate.Cfg.Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists("firstProject.db"))
                File.Delete("firstProject.db");

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
              .Create(false, true);
            //new SchemaUpdate(config).Execute(false,  true);
        }
    }
}
