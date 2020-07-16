using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Operacion_tarjeta
    {

        public int id_operacion_tarjeta { get; set; }
        [Key]

        public DateTime fecha { get; set; }

        public DateTime hora { get; set; }

        public decimal monto { get; set; }

        public string referencia { get; set; }
        [MaxLength(45)]

        public int id_usuario_receptor { get; set; }

        public int id_tarjeta { get; set; }

    }
}
