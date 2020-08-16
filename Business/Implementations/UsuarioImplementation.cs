﻿using ApiRestDesarrollo.Data;
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
using System.Net.Mail;
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

        public bool DesbloquearUsuario(string usuario1)
        {
            var usuario = _context.Usuario.FirstOrDefault(p => p.Usuario1.Contains(usuario1));
            if (usuario == null)
            {
                return false;
            }
            else if (usuario.Estatus != 3) 
            { 
                return false;
            }
            usuario.Estatus = 0;
            _context.saveChanges();
            return true;
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
                            tipo = tu.Descripcion,
                            idClave = clave.IdContrasena,
                            esatdo = usu.Estatus
                        }
                        ).FirstOrDefault();
            if (query != null && query.esatdo == 3) 
            {
                return new TokenValidate { login = false, mensaje = "Usuario bloqueado" };
            }
            if (query != null) 
            {
                var contrasena = _context.Contrasena.FirstOrDefault(p => p.IdContrasena == query.idClave);
                contrasena.IntentosFallidos = 0;
                _context.saveChanges();
                return new TokenValidate { login = true, idUser = query.Id, tipo = query.tipo, mensaje = "Login exitoso"};
            }
            var usuario = _context.Usuario.FirstOrDefault(p => p.Usuario1 == login.Usuario);
            if (usuario != null) {

                var contrasena = _context.Contrasena.FirstOrDefault(p => p.IdUsuario == usuario.IdUsuario);
                contrasena.IntentosFallidos ++;
                
                if (contrasena.IntentosFallidos == 5) 
                {
                    usuario.Estatus = 3;
                }
                _context.saveChanges();
                return new TokenValidate { login = false, intento = contrasena.IntentosFallidos, mensaje = "clave o usuario incorrecto" };
            }

            return new TokenValidate { login = false , mensaje = "clave o usuario incorrecto"};
        }

        public bool RegisterUser(CreateUserDto user)
        {
            var correo = _context.Usuario.FirstOrDefault(src => src.Email == user.Email);
            var usuario = _context.Usuario.FirstOrDefault(src => src.Usuario1 == user.Usuario);
            if (usuario == null && correo == null)
            {
                Contrasena contrasena = new Contrasena() { IdContrasena = _context.Contrasena.Count() *135, Contrasena1 = user.Contrasena};
                IList<Contrasena> contrasenas = new List<Contrasena>() {contrasena};
                Usuario usu = new Usuario() {
                IdUsuario = _context.Usuario.Count() *135,
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
                parametro = _context.Parametro.FirstOrDefault(p=> p.IdParametro == 1 ).Estatus
                };
                _context.Usuario.Add(usu);
                _context.saveChanges();
                
                return true;    
            }
            return false;
        }

        public bool recuperarContrasena(RecuperarModel usuarioRecuperar) //metodo booleano que devuelve true si se cambia la contraseña correctamente
        {

            if (buscarCorreo(usuarioRecuperar.email))
            {
                int nuevaContraseña = GenerarNuevaContrasena();// se genera la nueva contraseña
                //Console.Write(nuevaContraseña);
                modificarContarseña(usuarioRecuperar.email, nuevaContraseña);// se inserta en la base de datos la nueva contraseña
                EnviarCorreoContrasena(nuevaContraseña, usuarioRecuperar.email); // se le envia al usuario la nueva contraseña al correo
                return true;
            }
            else
                return false;

        }
        public bool actualizarContraseña(ModificarContraseñaModel contraseñaModificar)
        {
            var password = _context.Contrasena.FirstOrDefault(p => p.IdUsuario == contraseñaModificar.idUsuario && p.Contrasena1 == contraseñaModificar.ContrasenaVieja);
            if (password != null) 
            { 
                password.Contrasena1 = contraseñaModificar.nuevaContrasena;
                _context.saveChanges();
                return true;
            }
            return false;
        }
        private bool buscarCorreo(string email) // se verifica que el correo exista en la base de datos
        {
            var a = _context.Usuario.FirstOrDefault(p => p.Email.Contains(email));

            if (a != null)
                return true;
            else
                return false;
        }
        private void modificarContarseña(string email, int nuevaContrasena) // metodo que inserta la nueva contraseña en la base de datos
        {
            var usuario = _context.Usuario.FirstOrDefault(p => p.Email == email).IdUsuario;
            if (usuario > 0)
            {
                var password = _context.Contrasena.FirstOrDefault(p=>p.IdUsuario == usuario);
                password.Contrasena1 = nuevaContrasena.ToString();
            
            };
            _context.saveChanges();
            

        }
        private void EnviarCorreoContrasena(int contrasenaNueva, string correo) // metodo que envia el correo al usuario con su contraseña
        {

            string contraseña = "viwipkvmgnqfscjj";
            string mensaje = string.Empty;
            //Creando el correo electronico
            string destinatario = correo;
            string remitente = "linkdex2@gmail.com";
            string asunto = "Nueva contraseña Apps Easy";
            string cuerpoDelMesaje = "Su nueva contraseña es" + " " + Convert.ToString(contrasenaNueva);
            MailMessage ms = new MailMessage(remitente, destinatario, asunto, cuerpoDelMesaje);
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("linkdex2@gmail.com", contraseña);

            try
            {
                Task.Run(() =>
                {

                    smtp.Send(ms);
                    ms.Dispose();
                    //MessageBox.Show("Correo enviado, sirvase revisar su bandeja de entrada");
                }
                );

                // MessageBox.Show("Esta tarea puede tardar unos segundos, por favor espere.");
            }
            catch (Exception /*ex*/)
            {
                //MessageBox.Show("Error al enviar correo electronico: " + ex.Message);
            }






        }
        private int GenerarNuevaContrasena() // metodo que general la nueva contraseña
        {
            Random rd = new Random(DateTime.Now.Millisecond);
            int nuevaContrasena = rd.Next(100000, 999999);
            return nuevaContrasena;
        }

        public void UpdateParameter(int comision, int parametro)
        {
            Parametro parameter = _context.Parametro.FirstOrDefault(p=>p.IdParametro == 1);
            if (comision > 0)
            {
                parameter.comision = comision;
            }
            if (parametro > 0) 
            {
                parameter.Estatus = parametro; 
            }
            
            
            
        }
    }
}
