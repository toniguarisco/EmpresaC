using ApiRestDesarrollo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Data
{
    public interface IcommanderRepo
    {
        IEnumerable<Class> GetAppCommands();
        Class GetCommanderById(int id);
        void CreateClass(Class usuario);
        bool saveChanges();
        void UpdateUsuario(Class usuario);
        void DeleteUsuario(Class usuario);
    }
}
