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

        public UsuarioRead GetUserById(int IdUser)
        {
            var source = _context.Usuario.FirstOrDefault(e => e.IdUsuario == IdUser);
            if (source != null)
            {
                UsuarioRead usuario = new UsuarioRead
                {
                    usuario = source.Usuario1,
                    FechaRegistro = source.FechaRegistro,
                    NumIdentificacion = source.NumIdentificacion,
                    email = source.Email,
                    telefono = source.Telefono,
                    direccion = source.Direccion,
                    FkIdTipoUsuario = source.IdTipoUsuario,
                    FkIdTipoIdentificacion = source.IdTipoIdentificacion
                };
                return usuario;
            }
            return null;
        }

        public bool RetiroFondosCommerce(CreateOperacion createOperacion)
        {
            var cuenta = _context.Cuenta.FirstOrDefault(p => p.NumeroCuenta.Contains(createOperacion.cuenta));
            if (cuenta != null)
            {
                int refid = _context.OperacionCuenta.Count();
                OperacionCuenta operacionCuenta = new OperacionCuenta()
                {
                    Fecha = createOperacion.fecha,
                    Hora = createOperacion.hora,
                    IdCuenta = cuenta.IdCuenta,
                    Monto = createOperacion.monto,
                    operacion = false,
                    IdUsuarioReceptor = createOperacion.idUSuario,
                    IdOperacionCuenta = (refid + 1) * 135,
                    Referencia = "10789" + refid * 135, 
                    estatus = 0
                };
                _context.Add(operacionCuenta);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<ReadUserPersona> AdminGetUsersPersona(int IdTipoPersona)
        {
            var source = _context.Usuario.FirstOrDefault(e => e.IdTipoUsuario == IdTipoPersona);
            if( source != null)
            {
                var sourceid = _context.Persona.FirstOrDefault(e => e.IdUsuario == source.IdUsuario);
                var sourceec = _context.EstadoCivil.FirstOrDefault(e => e.IdEstadoCivil == sourceid.IdEstadoCivil);
                GetUserById(source.IdUsuario);
                var personas = (from p in _context.Persona
                             from u in _context.Usuario
                             where (u.IdTipoUsuario == IdTipoPersona) &&
                             (p.IdUsuario == u.IdUsuario)
                             select new ReadUserPersona
                             {
                                 Nombre = sourceid.Nombre,
                                 SegundoNombre = sourceid.SegundoNombre,
                                 Apellido = sourceid.Apellido,
                                 SegundoApellido = sourceid.SegundoApellido,
                                 FechaNacimiento = sourceid.FechaNacimiento,
                                 DescripcionEstadoCivil = sourceec.Descripcion

                             }
                             ).OrderBy(t => t.Nombre).ToList();
                return personas;
            }
            return null;
        }

        public List<ReadUserCommerce> AdminGetUsersCommerce(int IdTipoComercio)
        {
            var source = _context.Usuario.FirstOrDefault(e => e.IdTipoUsuario == IdTipoComercio);
            if (source != null)
            {
                GetUserById(source.IdUsuario);
                var sourceid = _context.Comercio.FirstOrDefault(e => e.IdUsuario == source.IdUsuario);
                var comercios = (from p in _context.Usuario
                                 from c in _context.Comercio
                                 where (p.IdTipoUsuario == IdTipoComercio) &&
                                 (c.IdUsuario == p.IdUsuario)
                                 select new ReadUserCommerce
                                 {
                                     RazonSocial = sourceid.RazonSocial,
                                     NombreRepresentante = sourceid.NombreRepresentante,
                                     ApellidoRepresentante = sourceid.ApellidoRepresentante
                                 }
                                 ).OrderBy(t => t.FkIdUsuario).ToList();
                return comercios;
            }
            return null;
        }

        public ReadOperationAccount GetBalance(int usuarioId)
        {
            List<OperacionCuenta> cuenta = _context.OperacionCuenta.Where(p => p.IdUsuarioReceptor == usuarioId && p.estatus != 1 && p.estatus != 3 && p.estatus != 10).ToList();
            List<ReadOperation> reads = new List<ReadOperation>();
            decimal saldo = 0;

            foreach (var item in cuenta)
            {
                string operacion = "_";
                if (item.operacion == true)
                {
                    saldo = saldo + item.Monto;
                    operacion = "+";
                }
                else if (item.operacion == false)
                {
                    saldo = saldo - item.Monto;
                    operacion = "-";
                }
                ReadOperation readOperations = new ReadOperation()
                {
                    fecha = item.Fecha.Day + "/" + item.Fecha.Month + "/" + item.Fecha.Year,
                    monto = item.Monto,
                    operation = operacion,
                    referencia = item.Referencia
                };
                reads.Add(readOperations);
            }
            ReadOperationAccount readOperationAccount = new ReadOperationAccount()
            {
                Monto = saldo,
                FkIdUsuarioReceptor = usuarioId,
                readOperations = reads.ToArray()
            };
            return readOperationAccount;
        }
    }
}