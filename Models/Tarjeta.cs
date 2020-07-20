using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Tarjeta
    {
        public int id_tarjeta { get; set; }
        [Key]

        public int numero_tarjeta { get; set; }

        public DateTime fecha_vencimiento { get; set; }

        public int cvc { get; set; }

        public int estatus { get; set; }

        public int id_usuario { get; set; }

        public int id_tipo_tarjeta { get; set; }

        public int id_banco { get; set; }

    }
}
