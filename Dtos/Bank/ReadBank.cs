using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos.Bank
{
    public class ReadBank
    {
        [MaxLength(45)]
        public string Nombre { get; set; }

        public int Estatus { get; set; }
    }
}
