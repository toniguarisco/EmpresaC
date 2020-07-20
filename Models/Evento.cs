using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public class Evento
    {

        public int id_evento { get; set; }
        [Key]

        public string codigo_evento { get; set; }
        [MaxLength(4)]

        public string evento { get; set; }
        [MaxLength(45)]

        public int estatus { get; set; }

    }
}
