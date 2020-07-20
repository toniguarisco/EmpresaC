using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Estado_civil
    {

        public int id_estado_civil { get; set; }
        [Key]

        public string descripcion { get; set; }
        [MaxLength(45)]

        public char codigo { get; set; }
        [MaxLength(1)]

        public int estatus { get; set; }

    }
}
