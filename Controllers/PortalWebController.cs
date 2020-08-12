using ApiRestDesarrollo.Data;
using ApiRestDesarrollo.Dtos;
using ApiRestDesarrollo.Dtos.User;
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

        [HttpPost("Actualizar Persona")]
        public ActionResult UpdateUserPerson(UpdateUserPersona person)
        {
            if (_portal.UpdateUserPerson(person))
            {
                _context.SaveChanges();
                return Ok();
                
            }
            return BadRequest("El usuario no es de tipo persona");
        }

        [HttpPost("Actualizar Comercio")]
        public ActionResult UpdateUserCommerce(UpdateUserCommerce commerce)
        {
            if (_portal.UpdateUserCommerce(commerce))
            {
                _context.SaveChanges();
                return Ok();

            }
            return BadRequest("El usuario no es de tipo comercio");
        }

    }
}
