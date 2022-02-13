using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoClientesMSA.Controllers.Dtos
{
    public class TelefoneDto
    {
        // id
        public int Id { get; set; }

        // size 30, required
        public string Numero { get; set; }

        // required, 
        public int Tipo { get; set; }
    }
}
