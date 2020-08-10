using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos.Operation
{
    public class ReadOperationAccount
    {
        public DateTime Fecha { get; set; }

        public DateTime Hora { get; set; }

        public int Monto { get; set; }

        public string ReferenciaOperacionCuenta { get; set; }

        public int FkIdUsuarioReceptor { get; set; }

        public int FkIdCuenta { get; set; }
    }
}
