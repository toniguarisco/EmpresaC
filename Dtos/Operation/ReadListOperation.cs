using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos.Operation
{
    public class ReadListOperation
    {
        public DateTime Fecha { get; set; }
        
        public decimal Monto { get; set; }

        public bool Operacion { get; set; }

        public string Referencia { get; set; }
    }
}
