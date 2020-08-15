using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos.Operation
{
    public class PagoTiendaDtos
    {
        public int IdUsuario { get; set; }
        public decimal monto { get; set; }
        public string Usuario { get; set; }
        public string Cuenta { get; set; }
        public int IdPago { get; set; }
    }
}
