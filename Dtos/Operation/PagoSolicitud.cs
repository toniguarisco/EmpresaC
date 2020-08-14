using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos.Operation
{
    public class PagoSolicitud
    {
        public DateTime FechaSolicitud { get; set; }
        public decimal Monto { get; set; }
        public string Estatus { get; set; }
        public string Referencia { get; set; }
        public string Solicitante { get; set; }
        public int IdPago { get; set; }
    
    }
}
