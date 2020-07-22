using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class Comercio
    {
        public int IdComercio { get; set; }
        public string RazonSocial { get; set; }
        public string NombreRepresentante { get; set; }
        public string ApellidoRepresentante { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
