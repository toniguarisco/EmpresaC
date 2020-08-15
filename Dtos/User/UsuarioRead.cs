using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos
{
    public class UsuarioRead
    {
        public int IdUsuario { get; set; }

        public string usuario { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int NumIdentificacion { get; set; }

        public string email { get; set; }

        public string telefono { get; set; }

        public string direccion { get; set; }

        public int Estatus { get; set; }

        public string clave { get; set; }

        public int FkIdTipoUsuario { get; set; }

        public int FkIdTipoIdentificacion { get; set; }
    }
}
