using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Tipo_operacion
    {

        public int id_tipo_operacion { get; set; }
        [Key]

        public string descripcion { get; set; }

        public int estatus { get; set; }

    }
}
