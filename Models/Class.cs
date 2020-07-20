using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Class
    {
        public int id { get; set; }

        public string nombre { get; set; }
        [MaxLength(45)]

        public string clave { get; set; }
        

    }
}
