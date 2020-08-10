using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos.Refund
{
    public class UpdateRefund
    {
        [MaxLength(45)]
        public string EstatusReintegro { get; set; }
    }
}
