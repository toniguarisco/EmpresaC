using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Tipo_cuenta
    {

        public int id_tipo_cuenta { get; set; }
        [Key]

        public string descripcion { get; set; }
        [MaxLength(45)]

        public int estatus { get; set; }

    }
}
