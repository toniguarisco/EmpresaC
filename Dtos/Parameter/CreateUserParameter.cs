using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos.Parameter
{
    public class CreateUserParameter
    {
        [MaxLength(45)]
        public string Validacion { get; set; }

        public int Estatus { get; set; }

        public int FkIdUsuario { get; set; }

        public int FkIdParametro { get; set; }

    }
}
