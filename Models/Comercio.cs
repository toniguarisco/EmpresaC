using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Comercio
    {
        public int id_comercio { get; set; }
        [Key]

        public string razon_social { get; set; }
        [MaxLength(200)]

        public string nombre_representante { get; set; }
        [MaxLength(45)]

        public string apellido_representante { get; set; }
        [MaxLength(45)]

        public int id_usuario { get; set; }


    }
}
