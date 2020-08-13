using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiRestDesarrollo.Models
{
    public partial class Persona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Apellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstadoCivil { get; set; }

        public virtual EstadoCivil IdEstadoCivilNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
