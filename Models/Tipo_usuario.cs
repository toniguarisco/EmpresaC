using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Models
{
    public class Tipo_usuario
    {
        public int id_tipo_usuario { get; set; }
        [Key]

        public string descripcion { get; set; }
        [MaxLength(45)]

        public int estatus { get; set; }

    }
}
