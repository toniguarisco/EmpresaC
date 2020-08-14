using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Controllers
{
    public class PagoDtos
    {
        public int IdUsuario { get; set; }
        public decimal monto { get; set; }
        public string Usuario { get; set; }
        public string Cuenta { get; set; }
    }
}
