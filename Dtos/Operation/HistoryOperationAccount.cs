using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos.Operation
{
    public class HistoryOperationAccount
    {

        public decimal Monto { get; set; }

        public int FkIdUsuarioReceptor { get; set; }

        public int FkIdCuenta { get; set; }

        public HistoryOperation[] historyOperations { get; set; }

    }
}
