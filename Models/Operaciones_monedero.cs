using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Operaciones_monedero
    {

        public int id_operaciones_monedero { get; set; }
        [Key]

        public int monto { get; set; }

        public DateTime fecha { get; set; }

        public DateTime hora { get; set; }

        public string referencia { get; set; }
        [MaxLength(45)]

        public int id_usuario { get; set; }

        public int id_tipo_operacion { get; set; }

    }
}
