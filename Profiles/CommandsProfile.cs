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
            CreateMap<Class, ComandRead>();
            CreateMap<ComaandCreateDto, Usuario>();
            CreateMap<ComaandCreateDto, Class>();
            CreateMap<UpdateUsuaarioDto, Usuario>();
            CreateMap<UpdateUsuaarioDto, Class>();
            CreateMap<Usuario, UsuarioRead>();

            //Mapeo para Usuario tipo comercio con el Dto CreateUserComerce
            CreateMap<Usuario, CreateUserComerce>()
                .ForMember(des => des.Usuario, opt => opt.MapFrom(src => src.Usuario1))
                .ForMember(des => des.FechaRegistro, opt => opt.MapFrom(src => src.FechaRegistro))
                .ForMember(des => des.NumIdentificacion, opt => opt.MapFrom(src => src.NumIdentificacion))
                .ForMember(des => des.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(des => des.Telefono, opt => opt.MapFrom(src => src.Telefono))
                .ForMember(des => des.Direccion, opt => opt.MapFrom(src => src.Direccion))
                .ForMember(des => des.EstatusUsuario, opt => opt.MapFrom(src => src.Estatus))
                .ForMember(des => des.Contrasena, opt => opt.Ignore())
                .ForMember(des => des.IntentosFallidos, opt => opt.Ignore())
                .ForMember(des => des.DescripcionTipoUsuario, opt => opt.Ignore())
                .ForMember(des => des.RazonSocial, opt => opt.Ignore())
                .ForMember(des => des.NombreRepresentante, opt => opt.Ignore())
                .ForMember(des => des.ApellidoRepresentante, opt => opt.Ignore())
                .ForMember(des => des.Codigo, opt => opt.Ignore())
                .ForMember(des => des.DescripcionTipoIdentificacion, opt => opt.Ignore())
                .ForMember(des => des.EstatusTipoIdentificacion, opt => opt.Ignore())
                ;
            CreateMap<Contrasena, CreateUserComerce>()
                .ForMember(des => des.Contrasena, opt => opt.MapFrom(src => src.Contrasena1))
                .ForMember(des => des.IntentosFallidos, opt => opt.MapFrom(src => src.IntentosFallidos));
            CreateMap<TipoUsuario, CreateUserComerce>()
                .ForMember(des => des.DescripcionTipoUsuario, opt => opt.MapFrom(src => src.Descripcion));
            CreateMap<Comercio, CreateUserComerce>()
                .ForMember(des => des.RazonSocial, opt => opt.MapFrom(src => src.RazonSocial))
                .ForMember(des => des.NombreRepresentante, opt => opt.MapFrom(src => src.RazonSocial))
                .ForMember(des => des.ApellidoRepresentante, opt => opt.MapFrom(src => src.ApellidoRepresentante));
            CreateMap<TipoIdentificacion, CreateUserComerce>()
                .ForMember(des => des.Codigo, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(des => des.DescripcionTipoIdentificacion, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(des => des.EstatusTipoIdentificacion, opt => opt.MapFrom(src => src.Estatus));
        
            //Mapeo para Usuario tipo persona con el Dto CreateUserPerson
        }

    }
}
