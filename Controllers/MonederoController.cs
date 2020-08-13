using ApiRestDesarrollo.Business.Interface;
using ApiRestDesarrollo.Data;
using ApiRestDesarrollo.Dtos;
using ApiRestDesarrollo.Dtos.Account;
using ApiRestDesarrollo.Dtos.Operation;
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
        private readonly IUsuarios _usuarios;
        private readonly IMapper _mapper;

        public MonederoController(IMonedero repository,
                                  IMapper mapper,
                                  IUsuarios usuarios)
        {
            _repository = repository;
            _mapper = mapper;
            _usuarios = usuarios;
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

        [HttpGet("InfoPersona")]
        public ActionResult<IEnumerable<ComandRead>> GetPersonaId(int id)
        {
            var person = _usuarios.GetPersona(id);
            if (person != null)
            {
                return Ok(person);
            };
            return BadRequest("el id no es valido");
        }
        [HttpPost("CuentaNueva")]
        public ActionResult AnadirCuenta (CreateCuenta cuenta)
        {
            //var commandItems = _repository.GetAppCommands();
            //var a = _mapper.Map<IEnumerable<ComandRead>>(commandItems);
            var log = _repository.AddCuenta(cuenta);
            if (log)
            {
                return Ok("cuenta añadida exitosamente");
            }
            return BadRequest("Puede ser que el usuario que ingreso o el banco no sean validos");
        }
        [HttpPost("AddSaldo")]
        public ActionResult AddSaldo(CreateOperacion operacion)
        {
            //var commandItems = _repository.GetAppCommands();
            //var a = _mapper.Map<IEnumerable<ComandRead>>(commandItems);
            var log = _repository.AddBalance(operacion);
            if (log)
            {
                return Ok("saldo añadido exitosamente");
            }
            return BadRequest("La cuenta no es valida");
        }

        [HttpPost("Reintegro")]
        public ActionResult Reintegro(int idUser, string referencia)
        {
            var log = _repository.reintegro(idUser,referencia);
            if (log)
            {
                return Ok("reintegro exitoso");
            }
            return BadRequest("Su referencia no es valida para reintegro o el usuario no existe");
        }

    }
}
