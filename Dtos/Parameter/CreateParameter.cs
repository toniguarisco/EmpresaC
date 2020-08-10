using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos.Parameter
{
    public class CreateParameter
    {
        [MaxLength(45)]
        public string NombreParametro { get; set; }

        public int EstatusParametro { get; set; }

        public int IdTipoParametro { get; set; }

        public int FkIdFrecuencia { get; set; }

        //FRECUENCIA 

        public char Codigo { get; set; }

        [MaxLength(45)]
        public string DescripcionFrecuencia { get; set; }

        public int EstatusFrecuencia { get; set; }

        //TIPO_PARAMETRO 

        [MaxLength(45)]
        public string DescripcionTipoParametro { get; set; }

        public int EstatusTipoParametro { get; set; }
    }
}
