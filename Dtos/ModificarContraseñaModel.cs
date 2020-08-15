using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos
{
    public class ModificarContraseñaModel
    {
        public string nuevaContraseña { get; set; }
        public int idUsuario { get; set; }
    }
}
