using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class Tarjeta
    {
        public Tarjeta()
        {
            OperacionTarjeta = new HashSet<OperacionTarjeta>();
        }

        public int IdTarjeta { get; set; }
        public int NumeroTarjeta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int Cvc { get; set; }
        public int Estatus { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoTarjeta { get; set; }
        public int IdBanco { get; set; }

        public virtual Banco IdBancoNavigation { get; set; }
        public virtual TipoTarjeta IdTipoTarjetaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<OperacionTarjeta> OperacionTarjeta { get; set; }
    }
}
