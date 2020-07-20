using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Dtos;
using ApiRestDesarrollo.Models;
using AutoMapper;
namespace ApiRestDesarrollo.Profiles
{
    public class CommandsProfile: Profile
    {
        public CommandsProfile() 
        {
            CreateMap<Usuario, ComandRead>();
            CreateMap<ComaandCreateDto, Usuario>();
            CreateMap<UpdateUsuaarioDto, Usuario>();
        }

    }
}
