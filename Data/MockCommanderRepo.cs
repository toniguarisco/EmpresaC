using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Data
{
    public class MockCommanderRepo : IcommanderRepo
    {
        public void CreateUsuario(usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void DeleteUsuario(usuario usuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<usuario> GetAppCommands()
        {
            var commands = new List<usuario>()
            {
                new usuario { id = 3, clave = "d", nombre = "dexter3" },
                new usuario { id = 2, clave = "e", nombre = "dexter2" },
                new usuario { id = 1, clave = "x", nombre = "dexter1" }
            };
            return commands;
        }
        
    

        public usuario GetCommanderById(int id)
        {
            return new usuario { id = 1, clave = "d", nombre = "dexter" };
        }

        public bool saveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateUsuario(usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
