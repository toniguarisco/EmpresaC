using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos
{
    public class CreatePayment
    {
        public DateTime FechaSolicitud { get; set; }

        public int Monto { get; set; }

        [MaxLength(45)]
        public string EstatusPago { get; set; }

        [MaxLength(45)]
        public string Referencia { get; set; }

        public int FkIdUsuarioSolicitante { get; set; }

        public int FkIdUsuarioReceptor { get; set; }

        //DATOS DE USUARIO NECESARIOS PARA EL PAGO
        [MaxLength(20)]
        public string UsuarioSolicitante { get; set; }

        [MaxLength(20)]
        public string UsuarioReceptor { get; set; }

        public int NumIdentificacionReceptor { get; set; }
    }
}
