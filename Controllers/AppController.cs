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
        
        
        
        [HttpPost("login")]
        public ActionResult GetAllCommands(LoginModel user)
        {
            //var commandItems = _repository.GetAppCommands();
            //var a = _mapper.Map<IEnumerable<ComandRead>>(commandItems);
            var log = _usuario.Login(user);
            if (log.login) { 
            return Ok(BuildToken(user, log.idUser, log.tipo ));
            }
            return BadRequest("Usuario o contraseña incorrecto");
        }

        [HttpPost("CreateComerce")]
        public ActionResult CreateUsuario(CreateUserDto user)
        {
            if (_usuario.RegisterUser(user)) {

                _context.SaveChanges();
                return Ok();
            }
            return BadRequest("El usuario ya existe");
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
                                            ) ;

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
