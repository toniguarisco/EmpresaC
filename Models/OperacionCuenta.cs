using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class OperacionCuenta
    {
        public int IdOperacionCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public decimal Monto { get; set; }
        public string Referencia { get; set; }
        public int IdCuenta { get; set; }
        public int IdUsuarioReceptor { get; set; }
        public bool operacion { get; set; }
        public virtual Cuenta IdCuentaNavigation { get; set; }
        public virtual Usuario IdUsuarioReceptorNavigation { get; set; }
    }
}
