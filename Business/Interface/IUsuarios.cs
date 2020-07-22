using ApiRestDesarrollo.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Business.Interface
{
    public interface IUsuarios
    {
        void CreateUsuario(CreateUserModel usuario);
        //IEnumerable<Usuario> GetAllUsuario();
        bool Login(LoginModel login);
    }
}
