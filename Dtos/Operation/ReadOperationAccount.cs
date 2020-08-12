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

        public decimal Monto { get; set; }

        public int FkIdUsuarioReceptor { get; set; }

        public int FkIdCuenta { get; set; }

        public ReadOperation[] readOperations { get; set; }
    }
}
