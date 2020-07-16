using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Models
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        [Key]

        public string usuario { get; set; }
        [MaxLength(20)]

        public DateTime fecha_registro { get; set; }

        public int num_identificacion { get; set; }

        public string email { get; set; }
        [MaxLength(200)]

        public string telefono { get; set; }
        [MaxLength(12)]

        public string direccion { get; set; }
        [MaxLength(500)]

        public int estatus { get; set; }

        public int id_tipo_usuario { get; set; }

        public int id_tipo_identificacion { get; set; }

    }
}
