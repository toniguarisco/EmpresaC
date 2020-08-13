using ApiRestDesarrollo.Dtos;
using ApiRestDesarrollo.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Business.Interface
{
    public interface IUsuarios
    {
        void CreateUsuario(CreateUserDto usuario);
        //IEnumerable<Usuario> GetAllUsuario();

        bool RegisterUser(CreateUserDto usuario);

        TokenValidate Login(LoginModel login);

        void UpdateContrasena(string login);

        ReadUserPersona GetPersona(int id);



    }
}
