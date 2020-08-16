using ApiRestDesarrollo.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos
{
    public class BotonPago
    {
        public DateTime fecha { get; set; }
        public decimal monto { get; set; }
        public string estatus { get; set; }
        public string referencia { get; set; }
        public string persona { get; set; }
        public string comercio { get; set; }
    }
}
