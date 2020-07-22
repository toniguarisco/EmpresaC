using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class Reintegro
    {
        public int IdReintegro { get; set; }
        public string FechaSolicitud { get; set; }
        public string Referencia { get; set; }
        public string Estatus { get; set; }
        public int IdUsuarioSolicitante { get; set; }
        public int IdUsuarioReceptor { get; set; }

        public virtual Usuario IdUsuarioReceptorNavigation { get; set; }
        public virtual Usuario IdUsuarioSolicitanteNavigation { get; set; }
    }
}
