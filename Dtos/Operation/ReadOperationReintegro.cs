using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos.Operation
{
    public class ReadOperationReintegro
    {
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public int Estatus { get; set; }
        public string UsuarioSolicitante { get; set; }
        public string Referencia { get; set; }
    }
}
