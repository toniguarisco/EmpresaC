using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class UsuarioOpcionMenu
    {
        public int Estatus { get; set; }
        public int IdUsuario { get; set; }
        public int IdOpcionMenu { get; set; }

        public virtual OpcionMenu IdOpcionMenuNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
