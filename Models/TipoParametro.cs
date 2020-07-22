using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class TipoParametro
    {
        public TipoParametro()
        {
            Parametro = new HashSet<Parametro>();
        }

        public int IdTipoParametro { get; set; }
        public string Descripcion { get; set; }
        public int Estatus { get; set; }

        public virtual ICollection<Parametro> Parametro { get; set; }
    }
}
