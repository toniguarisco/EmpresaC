using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class TipoTarjeta
    {
        public TipoTarjeta()
        {
            Tarjeta = new HashSet<Tarjeta>();
        }

        public int IdTipoTarjeta { get; set; }
        public string Descripcion { get; set; }
        public int Estatus { get; set; }

        public virtual ICollection<Tarjeta> Tarjeta { get; set; }
    }
}
