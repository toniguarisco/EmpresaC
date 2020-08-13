using ApiRestDesarrollo.Dtos;
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

        bool Login(LoginModel login);

        bool recuperarContrasena(RecuperarModel usuarioRecuperar);





    }
}
