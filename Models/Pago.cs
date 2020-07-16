using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Pago
    {

        public int id_pago { get; set; }
        [Key]

        public DateTime fecha_solicitud { get; set; }

        public decimal monto { get; set; }

        public string estatus { get; set; }
        [MaxLength(45)]

        public string referencia { get; set; }
        [MaxLength(45)]

        public int id_usuario_solicitante { get; set; }

        public int id_usuario_receptor { get; set; }

    }
}
