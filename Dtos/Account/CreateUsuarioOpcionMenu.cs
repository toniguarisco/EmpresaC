using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos.Account
{
    public class CreateUsuarioOpcionMenu
    {
        public int Estatus { get; set; }

        public int FkIdUsuario { get; set; }

        public int FkIdOpcionMenu { get; set; }

    }
}
