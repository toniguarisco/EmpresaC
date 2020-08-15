using ApiRestDesarrollo.Business.Interface;
using ApiRestDesarrollo.Dtos.User;
using ApiRestDesarrollo.Dtos.Account;
using ApiRestDesarrollo.Dtos.Operation;
using ApiRestDesarrollo.Dtos.Card;
using ApiRestDesarrollo.Models;
using ApiRestDesarrollo.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ApiRestDesarrollo.Business.Implementations
{
    public class PortalImplementation : IPortal
    {
        private readonly postgresContext _context;
        private readonly IMapper _mapper;

        public PortalImplementation(postgresContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public ReadUserCommerce GetCommerceById(int IdCommerce)
        {
            var source = _context.Comercio.FirstOrDefault(e => e.IdComercio == IdCommerce);
            if (source != null)
            {
                ReadUserCommerce comercio = new ReadUserCommerce
                    {
                        RazonSocial = source.RazonSocial,
                        NombreRepresentante = source.NombreRepresentante,
                        ApellidoRepresentante = source.ApellidoRepresentante,
                        FkIdUsuario = source.IdUsuario
                    };
                return comercio;
            }
            return null;
        }

        public bool CreateAccount(CreateCuenta account)
        {
            var id_usuario = _context.Usuario.FirstOrDefault(e => e.IdUsuario == account.IdUsuario);
            var id_banco = _context.Banco.FirstOrDefault(e => e.Nombre == account.Banco);
            var id_tipo_usuario = _context.TipoUsuario.FirstOrDefault(e => e.Descripcion == account.tipo);
            if ( (id_usuario != null) && (id_banco != null) && (id_tipo_usuario != null) )
            {         
                Cuenta cuenta = new Cuenta
                {
                    IdCuenta = _context.Cuenta.Count() + 1,
                    NumeroCuenta = account.Cuenta,
                    IdUsuario = account.IdUsuario
                };
                var query = (from idb in _context.Banco
                             from idtu in _context.TipoUsuario
                             where
                             idb.Nombre == account.Banco &&
                             idtu.Descripcion == account.tipo
                             select new
                             {
                                 idbanco = idb.IdBanco,
                                 idtipousuario = idtu.IdTipoUsuario
                             }
                    ).FirstOrDefault();               
                cuenta.IdBanco = query.idbanco;
                cuenta.IdTipoCuenta = query.idtipousuario;
                return true;
            }
            return false;
        }

        public ReadUserPersona GetPersonById(int IdPerson)
        {
            var source = _context.Persona.FirstOrDefault(e => e.IdPersona == IdPerson);
            if (source != null)
            {
                var src = _context.EstadoCivil.FirstOrDefault(e => e.IdEstadoCivil == source.IdEstadoCivil);
                ReadUserPersona persona = new ReadUserPersona
                {
                    Nombre = source.Nombre,
                    SegundoNombre = source.SegundoNombre,
                    Apellido = source.Apellido,
                    SegundoApellido = source.SegundoApellido,
                    FechaNacimiento = source.FechaNacimiento,
                    FkIdUsuario = source.IdUsuario,
                    DescripcionEstadoCivil = src.Descripcion
                };
                return persona;
            }
            return null;
        }

        public bool CreateOperation(CreateOperacion operacion)
        {

            return false;
        }

        public bool AddCard(CreateCard card)
        {
            var sourcet = _context.Tarjeta.FirstOrDefault(e => e.NumeroTarjeta == card.NumeroTarjeta);
            var sourceb = _context.Banco.FirstOrDefault(e => e.IdBanco == card.FkIdBanco);
            var sourceu = _context.Usuario.FirstOrDefault(e => e.IdUsuario == card.FkIdUsuario);
            if ((sourcet == null) && (sourceb != null) && (sourceu != null))
            {
                Tarjeta tarjeta = new Tarjeta
                {
                    NumeroTarjeta = card.NumeroTarjeta,
                    FechaVencimiento = card.FechaVencimiento,
                    Cvc = card.Cvc,
                    Estatus = card.EstatusTarjeta,
                    IdUsuario = card.FkIdUsuario,
                    IdTipoTarjeta = card.FkIdTipoTarjeta,
                    IdBanco = card.FkIdBanco
                };

                return true;
            }

            return false;
        }

        public List<ReadCard> GetUserCard(int IdUser)
        {
            var sourcet = _context.Tarjeta.FirstOrDefault(e => e.IdUsuario == IdUser);
            var sourceu = _context.Usuario.FirstOrDefault(e => e.IdUsuario == IdUser);
            if ((sourcet != null) && (sourceu != null))
            {
                var tarjetas = (from t in _context.Tarjeta
                                from u in _context.Usuario
                                from tt in _context.TipoTarjeta
                                from b in _context.Banco
                                where (u.IdUsuario == IdUser) &&
                                (t.IdBanco == b.IdBanco) &&
                                (t.IdTipoTarjeta == tt.IdTipoTarjeta)
                                select new ReadCard
                                {
                                    NumeroTarjeta = t.NumeroTarjeta,
                                    FechaVencimiento = t.FechaVencimiento,
                                    Cvc = t.Cvc,
                                    EstatusTarjeta = t.Estatus,
                                    DescripcionTipoTarjeta = tt.Descripcion,
                                    NombreBanco = b.Nombre
                                }

                        ).OrderBy(t => t.EstatusTarjeta == 0).ToList();
                return tarjetas;
            }
            return null;
        }
    }
}