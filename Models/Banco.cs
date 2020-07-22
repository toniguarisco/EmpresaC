﻿using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class Banco
    {
        public Banco()
        {
            Cuenta = new HashSet<Cuenta>();
            Tarjeta = new HashSet<Tarjeta>();
        }

        public int IdBanco { get; set; }
        public string Nombre { get; set; }
        public int Estatus { get; set; }

        public virtual ICollection<Cuenta> Cuenta { get; set; }
        public virtual ICollection<Tarjeta> Tarjeta { get; set; }
    }
}
