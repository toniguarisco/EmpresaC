using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Persona
    {

        public string nombre { get; set; }
        [MaxLength(45)]

        public string apellido { get; set; }
        [MaxLength(45)]

        public DateTime fecha_nacimiento { get; set; }

        public int id_usuario { get; set; }

        public int id_estado_civil { get; set; }

    }
}
