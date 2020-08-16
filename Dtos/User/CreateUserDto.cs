using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Enum;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos
{
    public class CreateUserDto
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
        public string nombre { get; set; }
        public string segundoNombre { get; set; }
        public string apelllido { get; set; }
        public string SegundoApelllido { get; set; }
        public DateTime fechaNacimiento { get; set; } 
        //CONTRASENA
        public string Contrasena { get; set; }



    }
}
