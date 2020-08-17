using ApiRestDesarrollo.Dtos;
using ApiRestDesarrollo.Dtos.Account;
using ApiRestDesarrollo.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Business.Interface
{
    public interface IUsuarios
    {
        
        bool RegisterUser(CreateUserDto usuario);
        TokenValidate Login(LoginModel login);
        bool recuperarContrasena(RecuperarModel usuarioRecuperar);
        bool actualizarContraseña(ModificarContraseñaModel contraseñaModificar);
        ReadUserPersona GetPersona(int id);
        bool DesbloquearUsuario(string usuario1);
        void UpdateParameter(int comision, int parametro);
        mensaje ValidacionPago(BotonPagoParticipantes participantes);
        bool RegisterComercio(CreateComercio user);

        string encriptacion(string secreto);
        

    }
}
