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
        [MaxLength(45)]
        public string DescripcionTipoUsuario { get; set; }

        //COMERCIO
        [MaxLength(200)]
        public string RazonSocial { get; set; }

        [MaxLength(45)]
        public string NombreRepresentante { get; set; }

        [MaxLength(45)]
        public string ApellidoRepresentante { get; set; }

        public int FkIdUsuario { get; set; }

        //TIPO_IDENTIFICACION

        public char Codigo { get; set; }

        [MaxLength(45)]
        public string DescripcionTipoIdentificacion { get; set; }

        public int EstatusTipoIdentificacion { get; set; }

    }
}
