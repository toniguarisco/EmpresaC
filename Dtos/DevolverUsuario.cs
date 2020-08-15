using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos
{
    public class DevolverUsuario
    {
        public string nombreUsuario { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string nombreRepresentante { get; set; }
        public string apellidoRepresentante { get; set; }
    }
}
