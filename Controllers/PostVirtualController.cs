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

        [HttpGet("Balance")]
        public ActionResult<IEnumerable<ComandRead>> GetBalance(int usuarioId, int cuentaId)
        {
            var saldo = _repository.GetBalance(usuarioId,cuentaId);
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
        public ActionResult<IEnumerable<ComandRead>> SolicitarPago(string UserSolicita, double Monto, string UserRecibe)
        {
            var solicitud = _repository.SolicitarPago(UserSolicita,Monto,UserRecibe);
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

        [HttpPut("ActualizarReintegro")]
        public ActionResult<IEnumerable<ComandRead>> ActualizarEstatusReintegro(int IdReintegro, string newEstatus)
        {
            var actualizar_reintegro = _repository.ActualizarEstatusReintegro(IdReintegro, newEstatus);
            if (actualizar_reinegro != false)
            {
                return Ok(solicitud);
            };
            return BadRequest("no existe esa solicitud de reintegro");
        }


    }
}
