using FluentNHibernate.Mapping;
using GestaoClientesMSA.Models;

namespace GestaoClientesMSA.Database.Mappings
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Id(p => p.Id);
            Map(p => p.Nome)
                .Length(100);
            Map(p => p.Email)
                .Unique()
                .Length(100);
            Map(p => p.DataNascimento)
                .CustomType("date")
                .Nullable();
            HasMany(p => p.Telefones)
                .Inverse()
                .Cascade.AllDeleteOrphan()
                .Not.LazyLoad()
                .Fetch.Join();
        }
    }
}
