using ApiRestDesarrollo.Business.Interface;
using ApiRestDesarrollo.Data;
using ApiRestDesarrollo.Dtos;
using ApiRestDesarrollo.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Controllers
{
    [Route("api/PostVirtual")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPost _repository;
        private readonly IMapper _mapper;


        public PostController(IPost repository,
                                  IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("actualizarperfil")]
        public ActionResult actualizarPerfil(PerfilModel usuarioPerfil)
        {

            if (_repository.actualizarPerfil(usuarioPerfil))
            {
                return Ok();
            }
            else
                return BadRequest("Ocurrio un error");

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
            if (solicitud != null)
            {
                return Ok(solicitud);
            };
            return BadRequest("datos invalidos");
        }

        [HttpGet("Reintegros")]
        public ActionResult<IEnumerable<ComandRead>> GetReintegros(int usuarioId)
        {
            var reintegros = _repository.GetReintegros(usuarioId);
            if (reintegros != null) {
                return Ok(reintegros);
            };
            return BadRequest("el id del usuario no es valido");
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

        [HttpPut("ActualizarReintegro")]
        public ActionResult<IEnumerable<ComandRead>> ActualizarEstatusReintegro(string RefReintegro, string newEstatus)
        {
            var actualizar_reintegro = _repository.ActualizarEstatusReintegro(RefReintegro, newEstatus);
            if (actualizar_reintegro != false)
            {
                return Ok(actualizar_reintegro);
            };
            return BadRequest("no existe esa solicitud de reintegro");
        }


    }
}
