using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos.Operation
{
    public class CantidadOperaciones
    {
        public string referencia { get; set; }
        public decimal monto { get; set; }
        public string tipoOperacion { get; set; }
        public int cantidadOperacion { get; set; }

    }
}
