using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class Parametro
    {
        public int IdParametro { get; set; }
        public string Nombre { get; set; }
        public int Estatus { get; set; }
        public int Comision { get; set; }
        public int IdTipoParametro { get; set; }
        public int IdFrecuencia { get; set; }

        public virtual Frecuencia IdFrecuenciaNavigation { get; set; }
        public virtual TipoParametro IdTipoParametroNavigation { get; set; }
    }
}
