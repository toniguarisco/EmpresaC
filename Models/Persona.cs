using System;
using System.Collections.Generic;

namespace ApiRestDesarrollo.Models
{
    public partial class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstadoCivil { get; set; }

        public virtual EstadoCivil IdEstadoCivilNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
