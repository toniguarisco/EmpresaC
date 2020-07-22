using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Data
{
    public class MockCommanderRepo : IcommanderRepo
    {
        public void CreateClass(Class usuario)
        {
            throw new NotImplementedException();
        }

        public void DeleteUsuario(Class usuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Class> GetAppCommands()
        {
            var commands = new List<Class>();
            //{
            //    new Class
            //    {
            //        id = 1,
            //        clave = "2",
            //        nombre = "1"

            //    },
            //};
            return commands;
        }
        
    

        public Class GetCommanderById(int id)
        {
            return new Class { };
            //{
            //    id = 1,
            //    clave = "2",
            //    nombre = "1"

            //};
        }

        public bool saveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateUsuario(Class usuario)
        {
            throw new NotImplementedException();
        }
    }
}
