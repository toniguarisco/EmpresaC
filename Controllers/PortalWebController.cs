﻿using ApiRestDesarrollo.Data;
using ApiRestDesarrollo.Dtos;
using ApiRestDesarrollo.Dtos.User;
using ApiRestDesarrollo.Dtos.Account;
using ApiRestDesarrollo.Dtos.Card;
using ApiRestDesarrollo.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Business.Interface;

namespace ApiRestDesarrollo.Controllers
{
    [Route("api/PortalWeb")]
    [ApiController]
    public class PortalWebController : ControllerBase
    {
        private readonly IcommanderRepo _repository;
        private readonly IPortal _portal;
        private readonly IMapper _mapper;
        private readonly postgresContext _context;

        public PortalWebController(IcommanderRepo repository,
                                      IPortal portal,
                                      IMapper mapper,
                                      postgresContext context)
        {
            _repository = repository;
            _portal = portal;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ComandRead>> GetAllCommands()
        {
            var commandItems = _repository.GetAppCommands();
            var a = _mapper.Map<IEnumerable<ComandRead>>(commandItems);
            return Ok(a);
        }

        [HttpPost("IngresarPersona")]
        public ActionResult UpdateUserPerson(UpdateUserPersona person)
        {
            if (_portal.UpdateUserPerson(person))
            {
                _context.SaveChanges();
                return Ok();
                
            }
            return BadRequest("El usuario no es de tipo persona");
        }


        [HttpPost("IngresarComercio")]
        public ActionResult UpdateUserCommerce(UpdateUserCommerce commerce)
        {
            if (_portal.UpdateUserCommerce(commerce))
            {
                _context.SaveChanges();
                return Ok();

            }
            return BadRequest("El usuario no es de tipo comercio");
        }

        [HttpGet("ObtenerComercioId")]
        public ActionResult<IEnumerable<ComandRead>> GetCommerceById(int IdCommerce)
        {
            var comercio = _portal.GetCommerceById(IdCommerce);
            if (comercio != null)
            {
                return Ok(comercio);
            }
            return BadRequest("No hay un comercio con el id ingresado");
        }

        [HttpGet("ObtenerPersonaId")]
        public ActionResult<IEnumerable<ComandRead>> GetPersonById(int IdPerson)
        {
            var persona = _portal.GetPersonById(IdPerson);
            if (persona != null)
            {
                return Ok(persona);
            }
            return BadRequest("No hay una persona con el id ingresado");
        }
        
        [HttpPost("IngresarCuenta")]
        public ActionResult CreateAccount(CreateCuenta account)
        {

            if (_portal.CreateAccount(account))
            {
                return Ok(account);
            }
            return BadRequest("No se pudo ingresar la cuenta o el usuario ya tiene asociado la cuenta");
        }

        [HttpPost("AñadirTarjeta")]
        public ActionResult AddCard(CreateCard card)
        {
            if (_portal.AddCard(card))
            {
                return Ok(card);
            }
            return BadRequest("Error al ingresar los datos");
        }

        [HttpGet("ListadoTarjetas")]
        public ActionResult<IEnumerable<ComandRead>> GetUserCard(int IdUser)
        {
            var card = _portal.GetUserCard(IdUser);
            if (card != null)
            {
                return Ok(card);
            }
            return BadRequest("No se pudo listar las tarjetas asociadas al usuario");
        }

        [HttpGet("UsuarioPorId")]
        public ActionResult<IEnumerable<ComandRead>> GetUserById(int IdUser)
        {
            var user = _portal.GetUserById(IdUser);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest("No se pudo listar las tarjetas asociadas al usuario");
        }

        [HttpGet("AdminListadoPersona")]
        public ActionResult<IEnumerable<ComandRead>> AdminGetUsersPersona(int IdTipoPersona)
        {
            var personas = _portal.AdminGetUsersPersona(IdTipoPersona);
            if( personas != null)
            {
                return Ok(personas);
            }
            return BadRequest("No se pudo obtener los usuarios");
        }

        [HttpGet("AdminListadoComercio")]
        public ActionResult<IEnumerable<ComandRead>> AdminGetUsersCommerce(int IdTipoPersona)
        {
            var comercios = _portal.AdminGetUsersCommerce(IdTipoPersona);
            if (comercios != null)
            {
                return Ok(comercios);
            }
            return BadRequest("No se pudo obtener los comercios");
        }

        [HttpGet("Balance")]
        public ActionResult<IEnumerable<ComandRead>> GetBalance(int usuarioId)
        {
            var saldo = _portal.GetBalance(usuarioId);
            if (saldo != null)
            {
                return Ok(saldo);
            };
            return BadRequest("el id del usuario no es valido o el id de la cuenta no es valido ");
        }
    }
}
