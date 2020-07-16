using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ApiRestDesarrollo.Models
{
    public class contrasena
    {

        public int id_contrasena { get; set; }
        [Key]

        public string Contrasena { get; set; }
        [MaxLength(20)]

        public int intetos_fallidos { get; set; }

        public int estatus { get; set; }

        public int id_usuario { get; set; }

    }
}
