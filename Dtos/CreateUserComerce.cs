using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos
{
    public class CreateUserComerce
    {
        //public int IdUsuario { get; set; }
        //[Key]

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

        //CONTRASENA
        public string Contrasena { get; set; }

        public int IntentosFallidos { get; set; }

        //TIPO USUARIO
        //public int IdTipoUsuario { get; set; }
        [MaxLength(45)]
        public string DescripcionTipoUsuario { get; set; }

        //COMERCIO
        [MaxLength(200)]
        public string RazonSocial { get; set; }

        [MaxLength(45)]
        public string NombreRepresentante { get; set; }

        [MaxLength(45)]
        public string ApellidoRepresentante { get; set; }

        //TIPO_IDENTIFICACION
        //[Key]
        //public int IdTipoIdentifiacion { get; set; }

        public char Codigo { get; set; }

        [MaxLength(45)]
        public string DescripcionTipoIdentificacion { get; set; }

        public int EstatusTipoIdentificacion { get; set; }

    }
}
