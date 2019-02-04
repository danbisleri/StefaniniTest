
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Configuration;

namespace Domain
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                                                     .Database(MsSqlConfiguration.MsSql2012
                                                     .ConnectionString(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString)
                                                     .ShowSql() )
                                             .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateHelper>())
                                            // .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                                             .BuildSessionFactory();


            return sessionFactory.OpenSession();
        }
    }
}
