﻿using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class Pago
    {
        public int IdPago { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public decimal Monto { get; set; }
        public string Estatus { get; set; }
        public string Referencia { get; set; }
        public int IdUsuarioSolicitante { get; set; }
        public int IdUsuarioReceptor { get; set; }

        public virtual Usuario IdUsuarioReceptorNavigation { get; set; }
        public virtual Usuario IdUsuarioSolicitanteNavigation { get; set; }
    }
}
