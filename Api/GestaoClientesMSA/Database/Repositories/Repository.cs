using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace GestaoClientesMSA.Database.Repositories
{
    public class Repository<TModel> : IRepository<TModel>
    {
        protected readonly ISessionFactory _sessionFactory;

        public Repository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public IList<TModel> All()
        {
            IList<TModel> allItems;

            using (var session = _sessionFactory.OpenSession())
            {
                allItems = session.Query<TModel>().ToList();
            }

            return allItems;
        }

        public TModel Get(int id)
        {
            TModel item;

            using (var session = _sessionFactory.OpenSession())
            {
                item = session.Get<TModel>(id);
            }

            return item;
        }

        public TModel Update(TModel model)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(model);
                transaction.Commit();
            }

            return model;
        }

        public void Delete(TModel model)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(model);
                transaction.Commit();
            }
        }
    }
}
