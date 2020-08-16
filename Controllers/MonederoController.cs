using ApiRestDesarrollo.Business.Interface;
using ApiRestDesarrollo.Data;
using ApiRestDesarrollo.Dtos;
using ApiRestDesarrollo.Dtos.Account;
using ApiRestDesarrollo.Dtos.Operation;
using ApiRestDesarrollo.Dtos.User;
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
        public ActionResult<IEnumerable<ReadOperationAccount>> GetBalance(int usuarioId)
        {
            var saldo = _repository.GetBalance(usuarioId);
            if (saldo != null) {
                return Ok(saldo);
            };
            return BadRequest("el id del usuario no es valido o el id de la cuenta no es valido ");
        }

        [HttpGet("Cuentas")]
        public ActionResult<IEnumerable<ReadAccounts>> GetAccountByUser(int usuarioId)
        {
            var accounts = _repository.GetAccountsUser(usuarioId);
            if (accounts != null)
            {
                return Ok(accounts);
            };
            return BadRequest("el id del usuario no es valido");
        }
        [HttpGet("PagosPendientes")]
        public ActionResult<IEnumerable<PagoSolicitud>> PagosPendientes(int usuarioId)
        {
            var pagos = _repository.pagoSolicitud(usuarioId);
            if (pagos != null)
            {
                return Ok(pagos);
            };
            return BadRequest("el id del usuario no es valido");
        }

        [HttpGet("BalanceEmail")]
        public ActionResult<IEnumerable<ReadOperationAccount>> GetBalanceByEmail(string email)
        {
            var accounts = _repository.GetBalanceByEmail(email);
            if (accounts != null)
            {
                return Ok(accounts);
            };
            return BadRequest("el correo no es valido");
        }

        [HttpGet("InfoPersona")]
        public ActionResult<ReadUserPersona> GetPersonaId(int id)
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
            if (log.flag)
            {
                return Ok("cuenta añadida exitosamente");
            }
            return BadRequest(log.mesage);
        }
        [HttpPost("AddSaldo")]
        public ActionResult AddSaldo(CreateOperacion operacion)
        {
            //var commandItems = _repository.GetAppCommands();
            //var a = _mapper.Map<IEnumerable<ComandRead>>(commandItems);
            var log = _repository.AddBalance(operacion);
            if (log.flag)
            {
                return Ok("saldo añadido exitosamente");
            }
            return BadRequest(log.mesage);
        }

        [HttpPost("Reintegro")]
        public ActionResult Reintegro(ReintegroDto reintegro)
        {
            var log = _repository.reintegro(reintegro);
            if (log.flag)
            {
                return Ok("reintegro exitoso");
            }
            return BadRequest(log.mesage);
        }

        [HttpPost("Transferencia")]
        public ActionResult Reintegro(PagoDtos tranfe)
        {
            var log = _repository.transferencia(tranfe);
            if (log.flag)
            {
                return Ok("transferencia exitosa");
            }
            return BadRequest(log.mesage);
        }

        [HttpPost("PagoPaypal")]
        public ActionResult Paypal(PagoDtos tranfe)
        {
            var log = _repository.paypal(tranfe);
            if (log.flag)
            {
                return Ok("Pago Exitoso");
            }
            return BadRequest(log.mesage);
        }

        [HttpPost("PagoTienda")]
        public ActionResult PagoTienda(PagoTiendaDtos pago)
        {
            var log = _repository.pagoTienda(pago);
            if (log.flag)
            {
                return Ok("Pago Exitoso");
            }
            return BadRequest(log.mesage);
        }
    }
}
