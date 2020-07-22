using ApiRestDesarrollo.Data;
using ApiRestDesarrollo.Dtos;
using ApiRestDesarrollo.Models;
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
         
                
		    public AppController(IUsuarios usuario,
                                 IMapper mapper,
                                 IConfiguration configuration
                                )
            {
                _usuario = usuario;
                _mapper = mapper;
                this._configuration = configuration;
            }
        
        
        
        [HttpPost("login")]
        public ActionResult GetAllCommands(LoginModel user)
        {
            //var commandItems = _repository.GetAppCommands();
            //var a = _mapper.Map<IEnumerable<ComandRead>>(commandItems);
            if (_usuario.Login(user)) { 
            return Ok(BuildToken(user));
            }
            return BadRequest("Usuario o contraseña incorrecto");
        }

        private IActionResult BuildToken(LoginModel user) 
        {
            var Claims = new[] { 
                new Claim(JwtRegisteredClaimNames.UniqueName, user.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Llave_Secreta"]));
            var Creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);
            JwtSecurityToken Token = new JwtSecurityToken(
                                            issuer: "ucab.com",
                                            audience: "ucab.com",
                                            claims: Claims,
                                            expires:expiration,
                                            signingCredentials: Creds
                                            );
            
            return Ok(new 
            { 
                Token = new JwtSecurityTokenHandler().WriteToken(Token),
                expiration = expiration.ToString()
            });
        }
    }

}
