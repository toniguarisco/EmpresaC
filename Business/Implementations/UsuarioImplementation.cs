using ApiRestDesarrollo.Data;
using ApiRestDesarrollo.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using ApiRestDesarrollo.Models;
using ApiRestDesarrollo.Business.Interface;
using ApiRestDesarrollo.Profiles.ComerceProfile;
using AutoMapper;

namespace ApiRestDesarrollo.Business.Implementations
{
    public class UsuarioImplementation: IUsuarios
    {
        private readonly postgresContext _context;
        private readonly IMapper _mapper;

        public UsuarioImplementation(postgresContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateUsuario(CreateUserComerce usuario)
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
            if (login.Email.Equals("Aron") && login.Clave.Equals("123")) {
                return true;
            }
            return false;
        }

        public bool RegisterUser(CreateUserComerce comerce)
        {
            var usuario = _context.Usuario.FirstOrDefault(src => src.Email == comerce.Email);
           
            if (usuario == null)
            {
                var usermapper = _mapper.Map<Usuario>(comerce);
                var contrasenamapper = _mapper.Map<Contrasena>(comerce);
                var comercemapper = _mapper.Map<Comercio>(comerce);
                _context.Usuario.Add(usermapper);
                _context.Contrasena.Add(contrasenamapper);
                _context.Comercio.Add(comercemapper);
                return true;    
            }
            return false;
        }
        
    }
}
