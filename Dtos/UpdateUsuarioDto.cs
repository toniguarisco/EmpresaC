using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos
{
    public class UpdateUsuaarioDto
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string clave { get; set; }
    }
}