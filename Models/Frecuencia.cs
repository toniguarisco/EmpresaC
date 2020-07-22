﻿using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class Frecuencia
    {
        public Frecuencia()
        {
            Parametro = new HashSet<Parametro>();
        }

        public int IdFrecuencia { get; set; }
        public char Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Estatus { get; set; }

        public virtual ICollection<Parametro> Parametro { get; set; }
    }
}
