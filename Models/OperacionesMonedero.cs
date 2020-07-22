using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class OperacionesMonedero
    {
        public int IdOperacionesMonedero { get; set; }
        public int Monto { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Referencia { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoOperacion { get; set; }

        public virtual TipoOperacion IdTipoOperacionNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
