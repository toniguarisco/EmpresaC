using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Parametro
    {

        public int id_parametro { get; set; }
        [Key]

        public string nombre { get; set; }
        [MaxLength(45)]

        public int estatus { get; set; }

        public int id_tipo_parametro { get; set; }

        public int id_frecuencia { get; set; }

    }
}
