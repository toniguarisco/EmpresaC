using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class TipoOperacion
    {
        public TipoOperacion()
        {
            OperacionesMonedero = new HashSet<OperacionesMonedero>();
        }

        public int IdTipoOperacion { get; set; }
        public string Descripcion { get; set; }
        public int Estatus { get; set; }

        public virtual ICollection<OperacionesMonedero> OperacionesMonedero { get; set; }
    }
}
