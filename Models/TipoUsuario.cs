using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string Descripcion { get; set; }
        public int Estatus { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
