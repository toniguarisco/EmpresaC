using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class Evento
    {
        public Evento()
        {
            Bitacora = new HashSet<Bitacora>();
        }

        public int IdEvento { get; set; }
        public string CodigoEvento { get; set; }
        public string Evento1 { get; set; }
        public int? Estatus { get; set; }

        public virtual ICollection<Bitacora> Bitacora { get; set; }
    }
}
