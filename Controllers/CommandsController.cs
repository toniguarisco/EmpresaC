using ApiRestDesarrollo.Data;
using ApiRestDesarrollo.Dtos;
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
    //api/comands
    [Route("api/commands")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CommandsController : ControllerBase
    {
        private readonly IcommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(IcommanderRepo repository,
                                  IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //get api/commands
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<ComandRead>> GetAllCommands()
        {
            var commandItems = _repository.GetAppCommands();
            var a = _mapper.Map<IEnumerable<ComandRead>>(commandItems);
            return Ok(a);
        }

        //get 
        [HttpGet("Estado200")]
        public ActionResult<Usuario> Estado200()
        {
            //usuario usuario = new usuario() { nombre = algo, clave ="5" , id = 0};
            //if (algo == null)
            //{
            //    return BadRequest();
            //}
            return Ok("Feliz cumpleaños lidux");
        }

        //get api/commands/{5}
        [HttpGet("{id}")]
        public ActionResult<ComandRead> GetComandById(int Id)
        {
            var commanItem = _repository.GetCommanderById(Id);
            if (commanItem != null)
            {
                return Ok(_mapper.Map<ComandRead>(commanItem));
            }
            return NotFound();

        }
        //Post
        [HttpPost]
        public ActionResult<ComandRead> CreateUsuario(ComaandCreateDto usuarioIn)
        {
            var comandModel = _mapper.Map<Class>(usuarioIn);
            _repository.CreateClass(comandModel);
            _repository.saveChanges();
            return Ok();
        }

        //put
        //[HttpPut("{id}")]
        //public ActionResult UpdateUsuario(int id, UpdateUsuaarioDto usuarioDto)
        //{
        //    var usuario = _repository.GetCommanderById(id);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }
        //    _mapper.Map(usuarioDto, usuario);
        //    _repository.UpdateUsuario(usuario); //teorico en caso de necesitar hacer algo mas con el update
        //    _repository.saveChanges();
        //    return NoContent();
        //}

        //delete
        [HttpDelete("{id}")]
        public ActionResult DeleteUsuario(int id)
        {
            var commanItem = _repository.GetCommanderById(id);
            if (commanItem == null)
            {
                return NotFound();
            }
            _repository.DeleteUsuario(commanItem);
            _repository.saveChanges();
            return NoContent();
        }

    }
}
