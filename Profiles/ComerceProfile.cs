using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ApiRestDesarrollo.Models;
using ApiRestDesarrollo.Dtos;

namespace ApiRestDesarrollo.Profiles.ComerceProfile
{
    public class ComerceProfile : Profile
    {
        public ComerceProfile()
        {
            CreateMap<Usuario, CreateUserComerce>();
            CreateMap<CreateUserComerce, Usuario>();
        }
    }
}
