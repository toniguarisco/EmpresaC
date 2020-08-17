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
using ApiRestDesarrollo.Dtos.User;
using ApiRestDesarrollo.Dtos.Operation;
using ApiRestDesarrollo.Enum;
using ApiRestDesarrollo.Dtos.Account;

namespace ApiRestDesarrollo.Business.Implementations
{
    public class UsuarioImplementation : IUsuarios
    {
        private readonly postgresContext _context;
        private readonly IMapper _mapper;
        

        public UsuarioImplementation(postgresContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
            var Persona = (from usu in _context.Usuario
                           from p in _context.Persona
                           where
                           usu.IdUsuario == p.IdUsuario
                           && usu.IdUsuario == id 
                           //&& usu.IdTipoUsuario == 2 
                            select new ReadUserPersona
                            {
                                Apellido = p.Apellido,
                                direccion = usu.Direccion,
                                email = usu.Direccion,
                                Nombre = p.Nombre,
                                SegundoApellido = p.SegundoApellido,
                                SegundoNombre = p.SegundoNombre,
                                telefono = usu.Telefono,
                                usuario = usu.Usuario1
                            }).FirstOrDefault();

            if (Persona != null)
            { 
                return Persona;
            }
            return null;
        }

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
                NumIdentificacion = 0,
                Telefono = user.Telefono,
                Direccion = user.Direccion,
                Contrasena = contrasenas,
                Estatus = 1,
                IdTipoUsuario = 2,
                IdTipoIdentificacion = 2,
                parametro = _context.Parametro.FirstOrDefault(p=> p.IdParametro == 1 ).Estatus
                };
                Persona persona = new Persona()
                {
                    IdUsuarioNavigation = usu,
                    Apellido = user.apelllido,
                    FechaNacimiento = user.fechaNacimiento,
                    Nombre = user.nombre,
                    SegundoApellido = user.SegundoApelllido,
                    SegundoNombre = user.segundoNombre,
                    IdPersona = _context.Persona.Count() * 135
                };
                //_context.Usuario.Add(usu);
                _context.Persona.Add(persona);
                _context.saveChanges();
                return true;    
            }
            return false;
        }

        public bool RegisterComercio(CreateComercio user)
        {
            var correo = _context.Usuario.FirstOrDefault(src => src.Email == user.Email);
            var usuario = _context.Usuario.FirstOrDefault(src => src.Usuario1 == user.Usuario);
            if (usuario == null && correo == null)
            {
                Contrasena contrasena = new Contrasena() { IdContrasena = _context.Contrasena.Count() * 135, Contrasena1 = user.Contrasena };
                IList<Contrasena> contrasenas = new List<Contrasena>() { contrasena };
                Comercio comercio = new Comercio()
                {
                    IdComercio = _context.Persona.Count() * 135,
                    ApellidoRepresentante = user.ApellidoRepresentante,
                    NombreRepresentante = user.nombreRepresentante,
                    RazonSocial = user.razon_social
                   
                };
                IList<Comercio> comercios = new List<Comercio>() { comercio };
                Usuario usu = new Usuario()
                {
                    IdUsuario = _context.Usuario.Count() * 135,
                    Email = user.Email,
                    Usuario1 = user.Usuario,
                    FechaRegistro = user.FechaRegistro,
                    NumIdentificacion = user.NumIdentificacion,
                    Telefono = user.Telefono,
                    Direccion = user.Direccion,
                    Contrasena = contrasenas,
                    Estatus = 1,
                    IdTipoUsuario = 1,
                    IdTipoIdentificacion = 1,
                    parametro = _context.Parametro.FirstOrDefault(p => p.IdParametro == 1).Estatus,
                    Comercio = comercios
                };
                
                //_context.Usuario.Add(usu);
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
            if (usuario >= 0)
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

        public mensaje ValidacionPago(BotonPagoParticipantes participantes)
        {
            mensaje mensaje = new mensaje();
            int IdPersona = GetUserIdByName(participantes.persona);
            int IdComercio = GetUserIdByName(participantes.comercio);
            var persona = _context.Usuario.FirstOrDefault(p=> p.IdUsuario == IdPersona);
            var saldo = GetBalance(IdPersona).Monto;
            var factura = _context.Pago.FirstOrDefault(p=>p.Referencia.Equals(participantes.referencia));
            if (saldo < factura.Monto) 
            {
                mensaje.mesage = "saldo insuficiente";
                return mensaje;
            }
            int refid = _context.OperacionCuenta.Count() * 135;
            var comisionPorcentaje = _context.Parametro.FirstOrDefault(p => p.IdParametro == 1).comision;
            DateTime fecha = DateTime.Now;
            TimeSpan hora = TimeSpan.Parse(fecha.Hour + ":" + fecha.Minute);
            decimal comision = factura.Monto * (Convert.ToDecimal(comisionPorcentaje) / 100);
            decimal total = factura.Monto - comision;
            OperacionCuenta operacionCuentaReceptor = new OperacionCuenta()
            {
                Fecha = fecha,
                Hora = hora,
                IdCuenta = 1,
                Monto = total,
                operacion = true,
                IdUsuarioReceptor = IdComercio,
                IdOperacionCuenta = refid  ,
                Referencia = "11578" + refid ,
                estatus = 0
            };
            OperacionCuenta operacionCuentaEnvia = new OperacionCuenta()
            {
                Fecha = fecha,
                Hora = hora,
                IdCuenta = 1,
                Monto = factura.Monto,
                operacion = false,
                IdUsuarioReceptor = IdPersona,
                IdOperacionCuenta = refid + 1,
                Referencia = "11578" + refid + 1,
                estatus = 0
            };
            OperacionCuenta operacionCuentaReceptor1 = new OperacionCuenta()
            {
                Fecha = fecha,
                Hora = hora,
                IdCuenta = 1,
                Monto = comision,
                operacion = true,
                IdUsuarioReceptor = IdComercio,
                IdOperacionCuenta = refid + 2,
                Referencia = "11578" + refid + 2,
                estatus = 10
            };
            factura.Estatus = "pagado";
            _context.Add(operacionCuentaReceptor1);
            _context.Add(operacionCuentaReceptor);
            _context.Add(operacionCuentaEnvia);
            _context.saveChanges();
            mensaje.flag = true;
            mensaje.mesage = "se realizo el pago exitosamente";
            return mensaje;
        }

        private ReadOperationAccount GetBalance(int usuarioId)
        {
            List<OperacionCuenta> cuenta = _context.OperacionCuenta.Where(p => p.IdUsuarioReceptor == usuarioId && p.estatus != 1 && p.estatus != 3 && p.estatus != 10).ToList();
            List<ReadOperation> reads = new List<ReadOperation>();
            decimal saldo = 0;

            foreach (var item in cuenta)
            {
                string operacion = "_";
                if (item.operacion == true)
                {
                    saldo = saldo + item.Monto;
                    operacion = "+";
                }
                else if (item.operacion == false)
                {
                    saldo = saldo - item.Monto;
                    operacion = "-";
                }
                ReadOperation readOperations = new ReadOperation()
                {
                    fecha = item.Fecha.Day + "/" + item.Fecha.Month + "/" + item.Fecha.Year,
                    monto = item.Monto,
                    operation = operacion,
                    referencia = item.Referencia
                };
                reads.Add(readOperations);
            }
            ReadOperationAccount readOperationAccount = new ReadOperationAccount()
            {
                Monto = saldo,
                FkIdUsuarioReceptor = usuarioId,
                readOperations = reads.ToArray()
            };
            return readOperationAccount;
        }

        private int GetUserIdByName(string usuario) 
        {
            int Id = _context.Usuario.FirstOrDefault(p => p.Usuario1 == usuario).IdUsuario;
            if (Id >= 0) 
            {
                return Id;
            };
            return -1;
        }

        //public BotonPago BotonPago(BotonPagoParticipantes participantes)
        //{
        //    var pago = ValidacionPago(participantes);
        //    if (pago.flag)
        //    { 
        //        var factura = _context.Pago
        //    }
        //    return pago;
        //}
    }
}
