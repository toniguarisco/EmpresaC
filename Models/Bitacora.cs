using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class Bitacora
    {
        public int IdAuditoria { get; set; }
        public DateTime FechaBitacora { get; set; }
        public string DatosOperacion { get; set; }
        public string CausaError { get; set; }
        public int IdEvento { get; set; }
        public int IdUsuario { get; set; }

        public virtual Evento IdEventoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
