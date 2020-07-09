using ApiRestDesarrollo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Data
{
    public interface IcommanderRepo
    {
        IEnumerable<usuario> GetAppCommands();
        usuario GetCommanderById(int id);
        void CreateUsuario(usuario usuario);
        bool saveChanges();
        void UpdateUsuario(usuario usuario);
        void DeleteUsuario(usuario usuario);
    }
}
