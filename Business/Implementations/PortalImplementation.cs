using ApiRestDesarrollo.Business.Interface;
using ApiRestDesarrollo.Dtos.User;
using ApiRestDesarrollo.Models;
using ApiRestDesarrollo.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Business.Implementations
{
    public class PortalImplementation : IPortal
    {
        private readonly postgresContext _context;

        public PortalImplementation(postgresContext context)
        {
            _context = context;
        }

        public bool UpdateUserPerson(UpdateUserPersona person)
        {
            //El Id del tipo de usuario 2 es de persona
            var tipo_usuario = _context.Usuario.FirstOrDefault(src => src.IdTipoUsuario == 2);
            if (tipo_usuario != null)
            {
                Persona persona = new Persona 
                {
                    IdPersona = _context.Persona.Count() +1,
                    Nombre = person.Nombre,
                    SegundoNombre = person.SegundoNombre,
                    Apellido = person.Apellido,
                    SegundoApellido = person.SegundoApellido,
                    FechaNacimiento = person.FechaNacimiento,
                    IdUsuario = person.FkIdUsuario,
                };
                EstadoCivil estado_civil = new EstadoCivil();
                if (person.DescripcionEstadoCivil.Equals("soltero"))
                {
                    persona.IdEstadoCivil = 0;
                }
                else if (person.DescripcionEstadoCivil.Equals("casado"))
                {
                    persona.IdEstadoCivil = 1;
                }
                else if (person.DescripcionEstadoCivil.Equals("otro"))
                {
                    persona.IdEstadoCivil = 2;
                }
                estado_civil.Estatus = 1;

                _context.Persona.Add(persona);
                return true;
            }
            return false;
        }

        public bool UpdateUserCommerce(UpdateUserCommerce commerce)
        {
            //El id del tipo usuario comercio es igual a 1
            var tipo_usuario = _context.Usuario.FirstOrDefault(src => src.IdTipoUsuario == 1);
            if (tipo_usuario != null)
            {
                Comercio comercio = new Comercio
                {
                    IdComercio = _context.Comercio.Count() + 1,
                    RazonSocial = commerce.RazonSocial,
                    NombreRepresentante = commerce.NombreRepresentante,
                    ApellidoRepresentante = commerce.ApellidoRepresentante,
                    IdUsuario = commerce.FkIdUsuario
                };

                return true;
            }
            return false;
        }
    }
}