using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos
{
    public class CreateComercio
    {
        [MaxLength(20)]
        public string Usuario { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int NumIdentificacion { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(12)]
        public string Telefono { get; set; }

        [MaxLength(500)]
        public string Direccion { get; set; }
        public string razon_social { get; set; }
        public string nombreRepresentante { get; set; }
        public string ApellidoRepresentante { get; set; }
        
        //CONTRASENA
        public string Contrasena { get; set; }

    }
}
