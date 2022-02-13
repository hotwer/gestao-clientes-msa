using GestaoClientesMSA.Models;
using NHibernate;
using System;

namespace GestaoClientesMSA.Database.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IRepository<Cliente>
    {
        public ClienteRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {

        }
    }
}
