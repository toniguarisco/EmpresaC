using ApiRestDesarrollo.Data;
using ApiRestDesarrollo.Dtos;
using ApiRestDesarrollo.Models;
//using ApiRestDesarrollo.Profiles.ComerceProfile;
using AutoMapper;
using ApiRestDesarrollo.Business.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiRestDesarrollo.Business.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ApiRestDesarrollo.Controllers
{
    [Route("api/App")]
    [ApiController]
    
    public class AppController : ControllerBase
    {
        private readonly IUsuarios _usuario;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly postgresContext _context;


        public AppController(IUsuarios usuario,
                             IMapper mapper,
                             IConfiguration configuration,
                             postgresContext context
                                )
            {
                _usuario = usuario;
                _mapper = mapper;
                this._configuration = configuration;
                _context = context;
        }



        [HttpGet("clave")]
        public ActionResult Login(string algo)
        {
            return Ok(_usuario.encriptacion(algo));
        }


        [HttpPost("login")]
        public ActionResult Login(LoginModel user)
        {
            //var commandItems = _repository.GetAppCommands();
            //var a = _mapper.Map<IEnumerable<ComandRead>>(commandItems);
            var log = _usuario.Login(user);
            if (log.login) { 
            return Ok(BuildToken(user, log.idUser, log.tipo ));
            }
            return BadRequest(log.mensaje);
        }

        [HttpPost("recuperarContaseña")]
        public ActionResult RecuperarContaseña(RecuperarModel usuarioRecuperar)
        {

            if (_usuario.recuperarContrasena(usuarioRecuperar))
            {
                return Ok("Se envio un correo a: " + usuarioRecuperar.email + " con su nueva clave");
            }
            else
                return BadRequest("Ocurrio un error");

        }

        [HttpPost("modificarContraseña")]
        public ActionResult ModificarContraseña(ModificarContraseñaModel contraseñaModificar)
        {

            if (_usuario.actualizarContraseña(contraseñaModificar))
            {
                return Ok("Contraseña actualizada");
            }
            else
                return BadRequest("Ocurrio un error");

        }

        [HttpPost("CreatePersona")]
        public ActionResult CreatePersona(CreateUserDto user)
        {
            if (_usuario.RegisterUser(user))
            {
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest("El usuario o correo ya existe");
        }

        [HttpPost("CreateComercio")]
        public ActionResult CreatePersona(CreateComercio user)
        {
            if (_usuario.RegisterComercio(user))
            {
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest("El usuario o correo ya existe");
        }

        [HttpPost("BotonPago")]
        public ActionResult<BotonPago> BotonPago(BotonPagoParticipantes participantes)
        {
            if (TipoPersona(participantes.persona) == 1 || TipoPersona(participantes.persona) == 0)
            {
                return BadRequest("El usuario no es valido ");
            }
            if (TipoPersona(participantes.comercio) == 2 && TipoPersona(participantes.comercio) == 0)
            {
                return BadRequest("El comercio no es valido ");
            }
            var a = _usuario.ValidacionPago(participantes);
            if (a.flag)
            {
                var factura = _context.Pago.FirstOrDefault(p => p.Referencia.Equals(participantes.referencia));
                BotonPago boton = new BotonPago()
                {
                    comercio = participantes.comercio,
                    persona = participantes.persona,
                    referencia = participantes.referencia,
                    estatus = factura.Estatus,
                    fecha = DateTime.Now,
                    monto = factura.Monto
                };
                return Ok(boton);
            }
            return BadRequest(a.mesage);
        }

        [HttpPut("EstadoUsuario")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult ActualizarEstado(string usuario)
        {
            if (_usuario.DesbloquearUsuario(usuario))
            {
                return Ok();
            }
            return BadRequest("El usuario no esta bloqueado o no existe");
        }

        [HttpPut("Parametros")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult ActualizarParametro(int comision, int parametro)
        {
            _usuario.UpdateParameter(comision, parametro);
            _context.saveChanges();
            return Ok();
        }

       
        private int TipoPersona(string persona)
        {
            var usuarios = (from usu in _context.Usuario
                            from tipo in _context.TipoUsuario
                            where
                            usu.IdTipoUsuario == tipo.IdTipoUsuario
                            && usu.Usuario1 == persona
                            select new
                            {
                                tipo = tipo.IdTipoUsuario
                            }).FirstOrDefault();

            return usuarios.tipo;

        }
        private IActionResult BuildToken(LoginModel user, int idUser, string tipo)
        {
            var Claims = new[] {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Usuario),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PASAREMODEARROLLOCAPAZQUIENABE"));
            var Creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);
            JwtSecurityToken Token = new JwtSecurityToken(
                                            issuer: "ucab.com",
                                            audience: "ucab.com",
                                            claims: Claims,
                                            expires: expiration,
                                            signingCredentials: Creds
                                            );

            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(Token),
                expiration = expiration.ToString(),
                Id = idUser,
                tipo = tipo
            }); ;
        }

    }

}
