using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos.Operation
{
    public class DatosOperacion
    {
        public DateTime Fecha { get; set; }

        public TimeSpan Hora { get; set; }

        public decimal Monto { get; set; }

        public string Referencia { get; set; }

        public string tipoOperacion { get; set; }
    }
}
