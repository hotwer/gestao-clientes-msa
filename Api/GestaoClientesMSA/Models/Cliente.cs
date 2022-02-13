using System;
using System.Collections.Generic;

namespace GestaoClientesMSA.Models
{
    public class Cliente
    {
        // id
        public virtual int Id { get; protected set; }

        // size 100, required
        public virtual string Nome { get; set; }

        // size 255, required, unique
        public virtual string Email { get; set; }

        // optional - only date
        public virtual DateTime DataNascimento { get; set; }

        // optional
        public virtual IList<Telefone> Telefones { get; set; }

        public Cliente()
        {
            Telefones = new List<Telefone>();
        }

        public virtual void AddTelefone(Telefone telefone)
        {
            telefone.Cliente = this;
            Telefones.Add(telefone);
        }

        public virtual void RemoveTelefone(Telefone telefone)
        {
            telefone.Cliente = null;
            Telefones.Remove(telefone);
        }
    }
}
