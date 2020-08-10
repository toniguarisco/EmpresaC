using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos
{
    public class UsuarioRead
    {
        public string usuario { get; set; }

        public string email { get; set; }

        public string telefono { get; set; }

        public string direccion { get; set; }

        public string clave { get; set; }
    }
}
