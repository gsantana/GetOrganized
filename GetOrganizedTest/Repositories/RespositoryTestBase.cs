using FluentNHibernate.Cfg.Db;
using GetOrganized.Persistence.GetOrganized.Web.Persistence;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GetOrganizedTest.Repositories
{
    public class RespositoryTestBase
    {
        public ISession session { get; set; }

        public RespositoryTestBase()
        {
            NHibernateConfiguration.Init(
                SQLiteConfiguration.Standard.UsingFile("test_GetOrganized"),
                //MsSqlConfiguration.MsSql2008.ConnectionString(
                //builder => builder.Server("localhost").Database("test_GetOrganized").TrustedConnection()),
                RebuildDatabase
                );

            session = NHibernateConfiguration.CreateAndOpenSession();
        }


        public void Dispose()
        {
            if (session != null) session.Dispose();
        }

        private void RebuildDatabase(Configuration config)
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
