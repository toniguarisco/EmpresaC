using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos.Operation
{
    public class TotalComisiones
    {
        public decimal TotalComision { get; set; }
        public List<ReadComisiones> readComisiones { get; set; }

    }
}
