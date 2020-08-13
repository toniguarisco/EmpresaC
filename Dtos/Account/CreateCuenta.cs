using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos.Account
{
    public class CreateCuenta
    {
        public string Cuenta { get; set; }
        public string Banco { get; set; }
        public int IdUsuario { get; set; }
        public string tipo{ get; set; }

    }
}
