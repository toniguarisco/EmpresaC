using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos
{
    public class CreateBitacora
    {
        public DateTime Fecha { get; set; }

        public DateTime Hora { get; set; }

        [MaxLength(2500)]
        public string DatosOperacion { get; set; }

        [MaxLength(2500)]
        public string CausaError { get; set; }

        public int FkIdEvento { get; set; }

        public int FkIdUsuario { get; set; }

        //EVENTO

        [MaxLength(4)]
        public string CodigoEvento { get; set; }

        [MaxLength(45)]
        public string Evento { get; set; }

        public int EstatusEvento { get; set; }
    }
}
