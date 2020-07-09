using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Models
{
    public class usuario
    {
        public int id { get; set; }
        [MaxLength(5)]
        public string nombre { get; set; }
        public string clave { get; set; }
    }
}
