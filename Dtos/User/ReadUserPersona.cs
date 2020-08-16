using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos.User
{
    public class ReadUserPersona
    {
        [MaxLength(45)]
        public string Nombre { get; set; }
        [MaxLength(45)]
        public string SegundoNombre { get; set; }
        [MaxLength(45)]
        public string Apellido { get; set; }
        [MaxLength(45)]
        public string SegundoApellido { get; set; }
        public string DescripcionEstadoCivil { get; set; }
        public string usuario { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }

    }
}
