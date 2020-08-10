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
        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int FkIdUsuario { get; set; }

        public int FkIdEstadoCivil { get; set; }

        //ESTADO CIVIL

        [MaxLength(45)]
        public string DescripcionEstadoCivil { get; set; }

        public char CodigoEstadoCivil { get; set; }
    }
}
