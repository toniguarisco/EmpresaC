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
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ApiRestDesarrollo.Business.Implementations
{

    public class PortalImplementation : IPortal
    {
        private readonly postgresContext _context;
        private readonly IMapper _mapper;
      
        private decimal CalcularComision(List<OperacionCuenta> lista)
        {

            decimal comision = 0;

            foreach (var item in lista)
            {
                comision += item.Monto;
            }

            return comision;

        }

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
                    //FechaNacimiento = source.FechaNacimiento,
                    //FkIdUsuario = source.IdUsuario,
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
                             from ec in _context.EstadoCivil
                             where (u.IdTipoUsuario == IdTipoPersona) &&
                             (p.IdUsuario == u.IdUsuario) &&
                             (p.IdEstadoCivil == ec.IdEstadoCivil)
                             select new ReadUserPersona
                             {
                                 Nombre = p.Nombre,
                                 SegundoNombre = p.SegundoNombre,
                                 Apellido = p.Apellido,
                                 SegundoApellido = p.SegundoApellido,
                                 //FechaNacimiento = p.FechaNacimiento,
                                 DescripcionEstadoCivil = ec.Descripcion,
                                 //FkIdUsuario = p.IdUsuario
                                 
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
                                     RazonSocial = c.RazonSocial,
                                     NombreRepresentante = c.NombreRepresentante,
                                     ApellidoRepresentante = c.ApellidoRepresentante,
                                     FkIdUsuario = c.IdUsuario
                                 }
                                 ).OrderBy(t => t.RazonSocial).ToList();
                return comercios;
            }
            return null;
        }
     
        public HistoryOperationAccount GetBalance(int usuarioId)
        {
            List<OperacionCuenta> cuenta = _context.OperacionCuenta.Where(p => p.IdUsuarioReceptor == usuarioId && p.estatus != 1 && p.estatus != 3 && p.estatus != 10).ToList();
            List<HistoryOperation> reads = new List<HistoryOperation>();

            string CalcularTipoOperacion(string referencia)
            {
                // guardamos los primeros cuatro valores del campo de referencia para compararlo
                // con el tipo de operacion al que corresponden
                int identificadorTipoOperacion = (System.Convert.ToInt32(referencia.Substring(0, 4)));

                switch (identificadorTipoOperacion)
                {
                    case 5789:
                        return "recarga banco tarjeta";

                    case 3789:
                        return "transferencia de saldo para persona";

                    case 7543:
                        return "pago recibido";

                    case 1789:
                        return "pago por paypal";

                    case 4789:
                        return "reintegro";

                    case 2789:
                        return "pago a comercio";

                    default:
                        return "no aplica";


                }
            }

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
                HistoryOperation readOperations = new HistoryOperation()
                {
                 
                    fecha = item.Fecha.Day + "/" + item.Fecha.Month + "/" + item.Fecha.Year,
                    monto = item.Monto,
                    operation = operacion,
                    referencia = item.Referencia,
                    tipoOperacion = CalcularTipoOperacion(item.Referencia)
                };
                reads.Add(readOperations);
            }

            HistoryOperationAccount readOperationAccount = new HistoryOperationAccount()
            {
                Monto = saldo,
                FkIdUsuarioReceptor = usuarioId,
                historyOperations = reads.ToArray()
            };
            return readOperationAccount;
        }

        public TotalComisiones RecaudoComision()
        {
          
            //trae a la variable comercio, lista de comercios de en los usuarios
            var comercio = _context.Usuario.Where(p => p.IdTipoUsuario == 1);

            //trae a la variable comisiones, lista de operaciones de tipo comision
            var comisiones = _context.OperacionCuenta.Where(p => p.estatus == 10).ToList();
            decimal total = 0;

            List<ReadComisiones> reads = new List<ReadComisiones>();
            //por cada comercio
            foreach (var item in comercio)
            {
                //calcular el total de comisiones por empresa
                var lista = comisiones.Where(p => p.IdUsuarioReceptor == item.IdUsuario).ToList();
                    total = CalcularComision(lista);

                ReadComisiones read = new ReadComisiones()
                {
                    monto = total,
                    usuario = item.Usuario1
                };

                reads.Add(read);
                
            }

            return new TotalComisiones() { 
            readComisiones = reads.OrderByDescending(p=>p.monto).ToList(),
            TotalComision = CalcularComision(comisiones),
            };
               
           
        }

        public List<ReadListOperation> AdminGetOperation(int IdUsuario)
        {
            var source = _context.OperacionCuenta.FirstOrDefault(e => e.IdUsuarioReceptor == IdUsuario);
            if (source != null)
            {
                GetUserById(IdUsuario);
                var operaciones = (from oc in _context.OperacionCuenta
                                   from u in _context.Usuario
                                   where oc.IdUsuarioReceptor == u.IdUsuario
                                   select new ReadListOperation
                                   {
                                       Fecha = oc.Fecha,
                                       Monto = oc.Monto,
                                       Operacion = oc.operacion,
                                       Referencia = oc.Referencia
                                   }

                    ).OrderBy(e => e.Fecha).ToList();


                return operaciones;
            }

            return null;
        }

      
    }
}