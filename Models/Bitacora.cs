using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Bitacora
    {

        public int id_auditoria { get; set; }
        [Key]

        public DateTime fecha_bitacora { get; set; }

        public string datos_operacion { get; set; }
        [MaxLength(2500)]

        public string causa_error { get; set; }
        [MaxLength(2500)]

        public int id_evento { get; set; }

        public int id_usuario { get; set; }

    }
}
