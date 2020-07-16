using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Tipo_identificacion
    {

        public int id_tipo_identificacion { get; set; }
        [Key]

        public char codigo { get; set; }
        [MaxLength(1)]

        public string descripcion { get; set; }
        [MaxLength(45)]

        public int estatus { get; set; }

    }
}
