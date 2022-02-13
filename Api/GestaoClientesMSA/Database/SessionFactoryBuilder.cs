using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using GestaoClientesMSA.Database.Mappings;
using NHibernate;

namespace GestaoClientesMSA.Database
{
    public class SessionFactoryBuilder
    {
        public static ISessionFactory Build(string connectionString)
        {
            return Fluently
                .Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012
                        .ConnectionString(connectionString)
                )
                .Mappings(mapper =>
                {
                    // todo: automate by getting from assembly type
                    mapper.FluentMappings.Add<ClienteMap>();
                    mapper.FluentMappings.Add<TelefoneMap>();
                })
                .BuildSessionFactory();
        }
    }
}
