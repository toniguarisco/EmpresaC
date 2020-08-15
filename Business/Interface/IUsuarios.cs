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
        bool RegisterUser(CreateUserDto usuario);
        TokenValidate Login(LoginModel login);
        bool recuperarContrasena(RecuperarModel usuarioRecuperar);
        bool actualizarContraseña(ModificarContraseñaModel contraseñaModificar);
        ReadUserPersona GetPersona(int id);
        bool DesbloquearUsuario(string usuario1);
    }
}
