using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos.Account
{
    public class UpdateApplication
    {
        [MaxLength(45)]
        public string Nombre { get; set; }

        [MaxLength(45)]
        public string Descripcion { get; set; }

        [MaxLength(45)]
        public string Estatus { get; set; }
    }
}
