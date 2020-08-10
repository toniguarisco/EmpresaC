using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos.Account
{
    public class UpdateOpcionMenu
    {
        [MaxLength(45)]
        public string NombreOpcionMenu { get; set; }

        [MaxLength(45)]
        public string DescripcionOpcionMenu { get; set; }

        [MaxLength(200)]
        public string Url { get; set; }

        public int Posicion { get; set; }

        public int Estatus { get; set; }

        public int FkIdAplicacion { get; set; }
    }
}
