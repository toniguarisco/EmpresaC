using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos
{
    public class CreateUserPersona
    {
        [MaxLength(20)]
        public string Usuario { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int NumIdentificacion { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(12)]
        public string Telefono { get; set; }

        [MaxLength(500)]
        public string Direccion { get; set; }

        public int EstatusUsuario { get; set; }

        public int FkIdTipoUsuario { get; set; }

        public int FkIdTipoIdentificacion { get; set; }

        //CONTRASENA
        public string Contrasena { get; set; }

        public int IntentosFallidos { get; set; }

        //TIPO USUARIO
        //public int IdTipoUsuario { get; set; }
        [MaxLength(45)]
        public string DescripcionTipoUsuario { get; set; }

        //PERSONA

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

        //TIPO_IDENTIFICACION

        public char Codigo { get; set; }

        [MaxLength(45)]
        public string DescripcionTipoIdentificacion { get; set; }

        public int EstatusTipoIdentificacion { get; set; }
    }
}
