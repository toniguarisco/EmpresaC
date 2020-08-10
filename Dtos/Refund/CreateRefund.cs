using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos
{
    public class CreateRefund
    {
        [MaxLength(45)]
        public string FechaSolicitud { get; set; }
        
        [MaxLength(45)]
        public string Referencia { get; set; }

        [MaxLength(45)]
        public string EstatusReintegro { get; set; }

        public int FkUsuarioSolicitante { get; set; }

        public int FkUsuarioReceptor { get; set; }

        //DATOS DE USUARIO NECESARIOS PARA EL REINTEGRO

        [MaxLength(20)]
        public string UsuarioSolicitante { get; set; }

        [MaxLength(20)]
        public string UsuarioReceptor { get; set; }

        public int NumIdentificacionReceptor { get; set; }

    }
}
