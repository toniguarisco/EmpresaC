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
using System.Net;

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

        public void CreateUsuario(CreateUserDto usuario)
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
            var query = (from usu in _context.Usuario
                        from clave in _context.Contrasena
                        where
                        usu.IdUsuario == clave.IdUsuario &&
                        usu.Usuario1 == login.Usuario &&
                        clave.Contrasena1 == login.Clave
                        select new LoginModel
                        { 
                        Usuario = usu.Usuario1,
                        Clave = clave.Contrasena1
                        }).FirstOrDefault();
            if (query != null) {
                return true;
            }
            return false;
        }

        public bool RegisterUser(CreateUserDto user)
        {
            var correo = _context.Usuario.FirstOrDefault(src => src.Email == user.Email);
            var usuario = _context.Usuario.FirstOrDefault(src => src.Usuario1 == user.Usuario);
            if (usuario == null && correo == null)
            {
                Contrasena contrasena = new Contrasena() { IdContrasena = _context.Contrasena.Count() + 1, Contrasena1 = user.Contrasena};
                IList<Contrasena> contrasenas = new List<Contrasena>() {contrasena};
                Usuario usu = new Usuario() {
                IdUsuario = _context.Usuario.Count() + 1,
                Email = user.Email,
                Usuario1 = user.Usuario,
                FechaRegistro = user.FechaRegistro,
                NumIdentificacion = user.NumIdentificacion,
                Telefono = user.Telefono,
                Direccion = user.Direccion,
                Contrasena = contrasenas,
                Estatus = 1,
                IdTipoUsuario = user.tipo.GetHashCode(),
                IdTipoIdentificacion = user.tipo.GetHashCode(),
                };
                _context.Usuario.Add(usu);
                _context.saveChanges();
                return true;    
            }
            return false;
        }
        
    }
}
