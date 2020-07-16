using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Usuario_parametro
    {

        public string validacion { get; set; }
        [MaxLength(45)]

        public int estatus { get; set; }

        public int id_usuario { get; set; }

        public int id_parametros { get; set; }

    }
}
