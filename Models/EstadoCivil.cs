using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class EstadoCivil
    {
        public int IdEstadoCivil { get; set; }
        public string Descripcion { get; set; }
        public char Codigo { get; set; }
        public int Estatus { get; set; }
    }
}
