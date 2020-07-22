using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class TipoIdentificacion
    {
        public TipoIdentificacion()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdTipoIdentificacion { get; set; }
        public char Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Estatus { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
