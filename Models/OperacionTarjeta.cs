using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class OperacionTarjeta
    {
        public int IdOperacionTarjeta { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public decimal Monto { get; set; }
        public string Referencia { get; set; }
        public int IdUsuarioReceptor { get; set; }
        public int IdTarjeta { get; set; }

        public virtual Tarjeta IdTarjetaNavigation { get; set; }
        public virtual Usuario IdUsuarioReceptorNavigation { get; set; }
    }
}
