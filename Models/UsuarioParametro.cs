using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class UsuarioParametro
    {
        public string Validacion { get; set; }
        public int Estatus { get; set; }
        public int IdUsuario { get; set; }
        public int IdParametros { get; set; }

        public virtual Parametro IdParametrosNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
