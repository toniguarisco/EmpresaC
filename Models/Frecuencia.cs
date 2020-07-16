using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Frecuencia
    {

        public int id_frecuencia { get; set; }
        [Key]

        public char codigo { get; set; }
        [MaxLength(1)]

        public string descripcion { get; set; }
        [MaxLength(45)]

        public int estatus { get; set; }
        
    }
}
