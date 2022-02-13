using System.Collections.Generic;

namespace GestaoClientesMSA.Database.Repositories
{
    public interface IRepository<TModel>
    {
        IList<TModel> All();

        TModel Get(int id);

        TModel Update(TModel model);

        void Delete(TModel model);
    }
}
