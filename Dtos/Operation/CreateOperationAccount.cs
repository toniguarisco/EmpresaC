using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos
{
    public class CreateOperationAccount
    {
        public DateTime Fecha { get; set; }

        public DateTime Hora { get; set; }

        public int Monto { get; set; }
        
        public string ReferenciaOperacionCuenta { get; set; }

        public int FkIdUsuarioReceptor { get; set; }

        public int FkIdCuenta { get; set; }

        //CUENTA

        public int NumeroCuenta { get; set; }

        public int FkIdUsuario { get; set; }

        public int FkTipoCuenta { get; set; }

        public int FkIdBanco { get; set; }

        //BANCO

        [MaxLength(45)]
        public string NombreBanco { get; set; }

        public int EstatusBanco { get; set; }

        //TIPO_CUENTA

        [MaxLength(45)]
        public string Descripcion { get; set; }

        public int EstatusTipoCuenta { get; set; }
     }
}
