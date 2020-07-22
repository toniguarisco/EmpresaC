using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class OpcionMenu
    {
        public int IdOpcionMenu { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public int Posicion { get; set; }
        public int Estatus { get; set; }
        public int IdAplicacion { get; set; }

        public virtual Aplicacion IdAplicacionNavigation { get; set; }
    }
}
