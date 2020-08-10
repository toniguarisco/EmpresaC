using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos.User
{
    public class UpdateUserCommerce
    {
        [MaxLength(200)]
        public string RazonSocial { get; set; }

        [MaxLength(45)]
        public string NombreRepresentante { get; set; }

        [MaxLength(45)]
        public string ApellidoRepresentante { get; set; }

        public int FkIdUsuario { get; set; }
    }
}
