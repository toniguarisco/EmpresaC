using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Dtos.Event
{
    public class UpdateEvent
    {
        [MaxLength(45)]
        public string Evento { get; set; }

        public int EstatusEvento { get; set; }
    }
}
