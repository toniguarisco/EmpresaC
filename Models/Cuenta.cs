using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Cuenta
    {

        public int id_cuenta { get; set; }
        [Key]

        public string numero_cuenta { get; set; }
        [MaxLength(20)]

        public int id_usuario { get; set; }

        public int id_tipo_cuenta { get; set; }

        public int id_banco { get; set; }

    }
}
