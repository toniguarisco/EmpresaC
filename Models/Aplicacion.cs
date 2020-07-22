using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class Aplicacion
    {
        public Aplicacion()
        {
            OpcionMenu = new HashSet<OpcionMenu>();
        }

        public int IdAplicacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estatus { get; set; }

        public virtual ICollection<OpcionMenu> OpcionMenu { get; set; }
    }
}
