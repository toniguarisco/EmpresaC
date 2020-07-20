using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;

namespace ApiRestDesarrollo.Data
{
    public class MockCommanderRepo : IcommanderRepo
    {
        public void CreateUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void DeleteUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAppCommands()
        {
            var commands = new List<Usuario>()
            {
                new Usuario {
                    id_usuario = 4, 
                    usuario = "usuario_prueba", 
                    fecha_registro = new DateTime(2020,7,16), 
                    num_identificacion = 555444666, 
                    email = " anttogutierrez98@gmail.com ", 
                    telefono = "123456789012",
                    direccion = "Antimano",
                    estatus = 1,
                    id_tipo_usuario = 0,
                    id_tipo_identificacion = 0
                },
            };
            return commands;
        }
        
    

        public Usuario GetCommanderById(int id)
        {
            return new Usuario {
                usuario = "usuario_prueba", 
                fecha_registro = new DateTime(2020,7,16), 
                num_identificacion = 555444666, 
                email = " anttogutierrez98@gmail.com ", 
                telefono = "123456789012",
                direccion = "Antimano",
                estatus = 1,
                id_tipo_usuario = 0,
                id_tipo_identificacion = 0
            };
        }

        public bool saveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
