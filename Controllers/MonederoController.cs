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
    [Route("api/Monedero")]
    [ApiController]
    public class MonederoController : ControllerBase
    {
        private readonly IMonedero _repository;
        private readonly IMapper _mapper;

        public MonederoController(IMonedero repository,
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

        [HttpGet("BalanceEmail")]
        public ActionResult<IEnumerable<ComandRead>> GetBalanceByEmail(string email)
        {
            var accounts = _repository.GetBalanceByEmail(email);
            if (accounts != null)
            {
                return Ok(accounts);
            };
            return BadRequest("el correo no es valido");
        }


    }
}
