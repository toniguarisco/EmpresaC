using ApiRestDesarrollo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Data
{
    public interface IcommanderRepo
    {
        IEnumerable<Usuario> GetAppCommands();
        Usuario GetCommanderById(int id);
        void CreateUsuario(Usuario usuario);
        bool saveChanges();
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(Usuario usuario);
    }
}
