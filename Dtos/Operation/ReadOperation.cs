using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos.Operation
{
    public class ReadOperation
    {
        public string fecha { get; set; }
        public decimal monto { get; set; }
        public string operation { get; set; }
        public string referencia { get; set; }
    }
}
