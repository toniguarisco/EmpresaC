﻿using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class Contrasena
    {
        public int IdContrasena { get; set; }
        public string Contrasena1 { get; set; }
        public int IntentosFallidos { get; set; }
        public int Estatus { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
