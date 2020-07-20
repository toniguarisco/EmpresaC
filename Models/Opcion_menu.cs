using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Opcion_menu
    {
        public int id_opcion_menu { get; set; }
        [Key]

        public string nombre { get; set; }
        [MaxLength(45)]

        public string descipcion { get; set; }
        [MaxLength(45)]

        public string url { get; set; }
        [MaxLength(200)]

        public int posicion { get; set; }

        public int estatus { get; set; }

        public int id_aplicacion { get; set; }

    }
}
