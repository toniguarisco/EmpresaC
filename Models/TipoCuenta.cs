using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class TipoCuenta
    {
        public TipoCuenta()
        {
            Cuenta = new HashSet<Cuenta>();
        }

        public int IdTipoCuenta { get; set; }
        public string Descripcion { get; set; }
        public int Estatus { get; set; }

        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
}
