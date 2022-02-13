using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoClientesMSA.Controllers.Dtos
{
    public class ClienteDto
    {
        // id
        public int Id { get; set; }

        // size 100, required
        public string Nome { get; set; }

        // size 255, required, unique
        public string Email { get; set; }

        // optional - only date
        public DateTime DataNascimento { get; set; }

        // optional
        public List<TelefoneDto> Telefones { get; set; }
    }
}
