using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace GetOrganized.Persistence
{

    namespace GetOrganized.Web.Persistence
    {
        public class NHibernateConfiguration
        {
            public static ISessionFactory SessionFactory { get; private set; }

            public static void Init(IPersistenceConfigurer databaseConfig,
              Action<Configuration> schemaConfiguration)
            {
                SessionFactory = Fluently.Configure()
                  .Database(
                    databaseConfig)
                  .Mappings(m => m.FluentMappings.
                    AddFromAssemblyOf<NHibernateConfiguration>())
                  .ExposeConfiguration(schemaConfiguration)
                  .BuildSessionFactory();

                //var model = AutoMap.AssemblyOf<NHibernateConfiguration>()
                //  .Where(t => t.Namespace == "GetOrganized.Models.Domain");

                //SessionFactory = Fluently.Configure()
                //  .Database(databaseConfig)
                //  .Mappings(m => m.AutoMappings.Add(model));

                //SessionFactory.ExposeConfiguration(schemaConfiguration).BuildSessionFactory();
            }

            public static ISession CreateAndOpenSession()
            {
                return SessionFactory.OpenSession();
            }
        }
    }
}
