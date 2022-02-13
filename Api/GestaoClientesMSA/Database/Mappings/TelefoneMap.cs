using FluentNHibernate.Mapping;
using GestaoClientesMSA.Models;
using NHibernate.Mapping;

namespace GestaoClientesMSA.Database.Mappings
{
    public class TelefoneMap : ClassMap<Telefone>
    {
        public TelefoneMap()
        {
            Id(p => p.Id);
            Map(p => p.Numero)
                .Length(30);
            Map(p => p.Tipo)
                .CustomType("int");
            References(p => p.Cliente, "ClienteId");
        }
    }
}
