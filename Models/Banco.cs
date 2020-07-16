using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Banco
    {

        public int id_banco { get; set; }
        [Key]

        public string nombre { get; set; }

        public int estatus { get; set; }

    }
}
