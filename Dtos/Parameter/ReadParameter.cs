using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos.Parameter
{
    public class ReadParameter
    {
        [MaxLength(45)]
        public string NombreParametro { get; set; }

        public int EstatusParametro { get; set; }

        public int IdTipoParametro { get; set; }

        public int FkIdFrecuencia { get; set; }

        //FRECUENCIA

        public string DescripcionFrecuencia { get; set; }

        //TIPO_PARAMETRO
        public string DescripcionTipoParametro { get; set; }
    }
}
