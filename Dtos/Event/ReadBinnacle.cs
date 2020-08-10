using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos.Event
{
    public class ReadBinnacle
    {
        public DateTime Fecha { get; set; }

        public DateTime Hora { get; set; }

        [MaxLength(2500)]
        public string DatosOperacion { get; set; }

        [MaxLength(2500)]
        public string CausaError { get; set; }

        public int FkIdEvento { get; set; }

        public int FkIdUsuario { get; set; }
    }
}
