using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            OperacionCuenta = new HashSet<OperacionCuenta>();
        }

        public int IdCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoCuenta { get; set; }
        public int IdBanco { get; set; }

        public virtual Banco IdBancoNavigation { get; set; }
        public virtual TipoCuenta IdTipoCuentaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<OperacionCuenta> OperacionCuenta { get; set; }
    }
}
