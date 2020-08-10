using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos.Operation
{
    public class ReadOperationMonyh
    {
        public int Monto { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime Hora { get; set; }

        [MaxLength(45)]
        public string Referencia { get; set; }

        public int FkIdUsuario { get; set; }

        public int FkIdTipoOperacion { get; set; }
    }
}
