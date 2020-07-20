using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Aplicacion
    {
        public int id_aplicacion { get; set; }
        [Key]

        public string nombre { get; set; }
        [MaxLength(45)]

        public string descripcion { get; set; }
        [MaxLength(45)]

        public string estatus { get; set; }
        //[MaxLength(45)]                                   No me permite utilizar esta funcion si pongo estatus de ultimo. 

    }
}
