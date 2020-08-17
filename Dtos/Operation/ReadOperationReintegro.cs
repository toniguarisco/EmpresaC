using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos.Operation
{
    public class ReadOperationReintegro
    {
        public string UsuarioSolicitante { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public int Estatus { get; set; }
        public string Referencia { get; set; }
        
    }
}
