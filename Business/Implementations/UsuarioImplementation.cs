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
using ApiRestDesarrollo.Dtos.User;

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

        public ReadUserPersona GetPersona(int id)
        {
            var query = _context.Persona.FirstOrDefault(p => p.IdUsuario == id);
            if (query != null)
            { 
                var read = _mapper.Map<ReadUserPersona>(query);
                read.FkIdUsuario = query.IdUsuario;
                return read;
            }
            return null;
        }

        //public IEnumerable<Usuario> GetAllUsuario()
        //{
        //    var a = _context.Usuario.ToList();
        //    return a;
        //}

        public TokenValidate Login(LoginModel login)
        {
            var query = (from usu in _context.Usuario
                        from clave in _context.Contrasena
                        from tu in _context.TipoUsuario
                        where
                        usu.IdUsuario == clave.IdUsuario &&
                        tu.IdTipoUsuario == usu.IdTipoUsuario &&
                        (usu.Usuario1.Contains(login.Usuario) || usu.Email.Contains(login.Usuario))&&
                        clave.Contrasena1 == login.Clave
                        select new 
                        { 
                        Usuario = usu.Usuario1,
                        Clave = clave.Contrasena1,
                        Id = usu.IdUsuario,
                        tipo = tu.Descripcion
                        }).FirstOrDefault();
            if (query != null) {
                return new TokenValidate { login = true, idUser = query.Id, tipo = query.tipo};
            }
            return new TokenValidate { login = false};
        }
        

        public bool RegisterUser(CreateUserDto comerce)
        {
            var correo = _context.Usuario.FirstOrDefault(src => src.Email == comerce.Email);
            var usuario = _context.Usuario.FirstOrDefault(src => src.Usuario1 == comerce.Usuario);
            if (usuario == null && correo == null)
            {
                Contrasena contrasena = new Contrasena() { IdContrasena = _context.Contrasena.Count() + 1, Contrasena1 = comerce.Contrasena};
                IList<Contrasena> contrasenas = new List<Contrasena>() {contrasena};
                Usuario usu = new Usuario() {
                IdUsuario = _context.Usuario.Count() + 1,
                Email = comerce.Email,
                Usuario1 = comerce.Usuario,
                FechaRegistro = comerce.FechaRegistro,
                NumIdentificacion = comerce.NumIdentificacion,
                Telefono = comerce.Telefono,
                Direccion = comerce.Direccion,
                Contrasena = contrasenas,
                Estatus = 1,
                IdTipoUsuario = comerce.tipo.GetHashCode(),
                IdTipoIdentificacion = comerce.tipo.GetHashCode(),
                };
                _context.Usuario.Add(usu);
                _context.saveChanges();
                
                return true;    
            }
            return false;
        }

        public void UpdateContrasena(string login)
        {
            
        }
    }
}
