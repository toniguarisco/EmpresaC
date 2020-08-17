using ApiRestDesarrollo.Business.Interface;
using ApiRestDesarrollo.Data;
using ApiRestDesarrollo.Dtos;
using ApiRestDesarrollo.Dtos.Account;
using ApiRestDesarrollo.Dtos.Refund;
using ApiRestDesarrollo.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Controllers
{
    [Route("api/PostVirtual")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PostController : ControllerBase
    {
        private readonly IPost _repository;
        private readonly IMapper _mapper;


        public PostController(IPost repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("UsuarioDatos")]
        public ActionResult<IEnumerable<ComandRead>> GetUsuario(int usuarioId)
        {
            var datosUsuario = _repository.GetUsuario(usuarioId);
            if (datosUsuario != null)
            {
                return Ok(datosUsuario);
            };
            return BadRequest("el id del usuario no es valido");
        }

        [HttpGet("Balance")]
        public ActionResult<IEnumerable<ComandRead>> GetBalance(int usuarioId)
        {
            var saldo = _repository.GetBalance(usuarioId);
            if (saldo != null) {
                return Ok(saldo);
            };
            return BadRequest("el id del usuario no es valido o el id de la cuenta no es valido ");
        }

        [HttpGet("Reintegros")]
        public ActionResult<IEnumerable<ComandRead>> GetReintegros(int usuarioId)
        {
            var reintegros = _repository.GetReintegros(usuarioId);
            if (reintegros != null)
            {
                return Ok(reintegros);
            };
            return BadRequest("el id del usuario no es valido");
        }

        [HttpGet("Cuentas")]
        public ActionResult<IEnumerable<ComandRead>> GetAccountByUser(int usuarioId)
        {
            var accounts = _repository.GetAccountsUser(usuarioId);
            if (accounts != null)
            {
                return Ok(accounts);
            };
            return BadRequest("el id del usuario no es valido");
        }

        [HttpPost("SolicitarPago")]
        public ActionResult<IEnumerable<ComandRead>> SolicitarPago(SolicitarPago pago)
        {
            var solicitud = _repository.SolicitarPago(pago);
            var prueba = pago.ToString();
            if (solicitud != null)
            {
                return Ok(solicitud);
            };
            return BadRequest("datos invalidos");
        }

        [HttpPost("actualizarperfil")]
        public ActionResult actualizarPerfil(PerfilModel usuarioPerfil)
        {

            if (_repository.actualizarPerfil(usuarioPerfil))
            {
                return Ok();
            }
            else
                return BadRequest("Ocurrio un error");

        }

        [HttpPost("ActualizarReintegro")]
        public ActionResult<IEnumerable<ComandRead>> ActualizarEstatusReintegro(reintegroId reintegro)
        {
            var actualizar_reintegro = _repository.ActualizarEstatusReintegro(reintegro);
            if (actualizar_reintegro != false)
            {
                return Ok(actualizar_reintegro);
            };
            return BadRequest("no existe esa solicitud de reintegro");
        }

        
    }
}
