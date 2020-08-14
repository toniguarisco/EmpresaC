using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos.Operation
{
    public class CreateOperacion
    {
        public DateTime fecha { get; set; }
        public TimeSpan hora { get; set; }
        public decimal monto { get; set; }
        public int idUSuario { get; set; }
        public string cuenta { get; set; }
    }
}
