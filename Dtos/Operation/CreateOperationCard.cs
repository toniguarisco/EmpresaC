using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos
{
    public class CreateOperationCard
    {
        public DateTime Fecha { get; set; }

        public DateTime Hora { get; set; }

        public int Monto { get; set; }

        public string ReferenciaOperacionTarjeta { get; set; }

        public int FkIdUsuarioReceptor { get; set; }

        public int FkIdTarjeta { get; set; }

        //TARJETA

        public int NumeroTarjeta { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public int Cvc { get; set; }

        public int EstatusTarjeta { get; set; }

        public int FkIdUsuario { get; set; }

        public int FkIdTipoTarjeta { get; set; }

        public int FkIdBanco { get; set; }

        //TIPO_TARJETA 

        [MaxLength(45)]
        public string DescripcionTipoTarjeta { get; set; }

        public int EstatusTipoTarjeta { get; set; }
        
        //BANCO

        [MaxLength(45)]
        public string NombreBanco { get; set; }

        public int EstatusBanco { get; set; }
    }
}
