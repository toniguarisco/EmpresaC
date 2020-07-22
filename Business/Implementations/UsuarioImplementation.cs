using ApiRestDesarrollo.Data;
using ApiRestDesarrollo.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;
using ApiRestDesarrollo.Business.Interface;

namespace ApiRestDesarrollo.Business.Implementations
{
    public class UsuarioImplementation: IUsuarios
    {
        private readonly postgresContext _context;

        public UsuarioImplementation(postgresContext context)
        {
            _context = context;
        }

        public void CreateUsuario(CreateUserModel usuario)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Usuario> GetAllUsuario()
        //{
        //    var a = _context.Usuario.ToList();
        //    return a;
        //}

        public bool Login(LoginModel login)
        {
            if (login.email.Equals("Aron") && login.clave.Equals("123")) {
                return true;
            }
            return false;
        }
    }
}
