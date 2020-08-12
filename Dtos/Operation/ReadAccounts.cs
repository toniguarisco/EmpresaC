using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos.Operation
{
    public class ReadAccounts
    {
        public int idCuenta { get; set; }
        public string banco { get; set; }
        public string tipo { get; set; }
        public string cuenta { get; set; }
    }
}
