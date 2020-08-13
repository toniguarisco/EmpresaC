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
using System.Net.Mail;

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
        private bool buscarCorreo(string email) // se verifica que el correo exista en la base de datos
        {
            var a = _context.Usuario.FirstOrDefault(p => p.Email == email);


            if (a != null)
                return true;
            else
                return false;
        }
        private void modificarContarseña(string email, int nuevaContraseña) // metodo que inserta la nueva contraseña en la base de datos
        {
            Usuario a = new Usuario();
            a = _context.Usuario.FirstOrDefault(p => p.Email == email);
            Contrasena b = new Contrasena();
            b.IdContrasena = _context.Contrasena.Count() + 1;
            b.Contrasena1 = Convert.ToString(nuevaContraseña);
            b.IdUsuario = a.IdUsuario;
            b.IntentosFallidos = 0;
            b.Estatus = 1;
            _context.Contrasena.Add(b);
            //_context.Usuario.Update(a);
            _context.saveChanges();
            /* a.Direccion = Convert.ToString(nuevaContraseña);
             _context.Usuario.Update(a);
             _context.SaveChanges();*/


        }
        private void EnviarCorreoContrasena(int contrasenaNueva, string correo) // metodo que envia el correo al usuario con su contraseña
        {
            string contraseña = "Desarrollo.2020";
            string mensaje = string.Empty;
            //Creando el correo electronico
            string destinatario = correo;
            string remitente = "desarrollo2020gato@gmail.com";
            string asunto = "Nueva contraseña Apps Easy";
            string cuerpoDelMesaje = "Su nueva contraseña es" + " " + Convert.ToString(contrasenaNueva);
            MailMessage ms = new MailMessage(remitente, destinatario, asunto, cuerpoDelMesaje);


            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("desarrollo2020gato@gmail.com", contraseña);

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

    }
}
