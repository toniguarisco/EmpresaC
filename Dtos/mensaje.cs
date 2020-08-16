using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Dtos
{
    public class mensaje
    {
        public mensaje()
        {
            flag = false;
            mesage = "No eres un usuario valido";
        }
        public bool flag { get; set; }
        public string mesage { get; set; }
    }
}
