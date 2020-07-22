using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos
{
    public class ComandRead
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }
}
