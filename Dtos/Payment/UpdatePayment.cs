using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos.Payment
{
    public class UpdatePayment
    {
        [MaxLength(45)]
        public string EstatusPago { get; set; }
    }
}
