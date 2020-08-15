using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos.Card
{
    public class CreateCard
    {
        public int NumeroTarjeta { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public int Cvc { get; set; }

        public int EstatusTarjeta { get; set; }

        public int FkIdUsuario { get; set; }

        public int FkIdTipoTarjeta { get; set; }

        public int FkIdBanco { get; set; }
    }
}
