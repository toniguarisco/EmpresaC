using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos.User
{
    public class TokenValidate
    {
        public bool login { get; set; }
        public int idUser { get; set; }
        public int intento { get; set; }
        public string tipo { get; set; }
        public string mensaje { get; set; }
        
    }
}
