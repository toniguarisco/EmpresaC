﻿using ApiRestDesarrollo.Data;
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
    [Route("api/App")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly IcommanderRepo _repository;
        private readonly IMapper _mapper;

        public AppController(IcommanderRepo repository,
                                    IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ComandRead>> GetAllCommands()
        {
            var commandItems = _repository.GetAppCommands();
            var a = _mapper.Map<IEnumerable<ComandRead>>(commandItems);
            return Ok(a);
        }

    }

}
