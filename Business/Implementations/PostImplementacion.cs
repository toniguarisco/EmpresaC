using ApiRestDesarrollo.Business.Interface;
using ApiRestDesarrollo.Dtos;
using ApiRestDesarrollo.Dtos.Operation;
using ApiRestDesarrollo.Dtos.Payment;
using ApiRestDesarrollo.Dtos.Refund;
using ApiRestDesarrollo.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Business.Implementations
{
    public class PostImplementacion:IPost
    {
        private readonly postgresContext _context;
        private readonly IMapper _mapper;
        public PostImplementacion(postgresContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool actualizarPerfil(PerfilModel usuarioPerfil)
        {
            try
            {
                Usuario a = new Usuario();
                a = _context.Usuario.FirstOrDefault(p => p.IdUsuario == usuarioPerfil.idUsuario);
                Comercio c = new Comercio();
                c = _context.Comercio.FirstOrDefault(p => p.IdUsuario == a.IdUsuario);
                a.Usuario1 = usuarioPerfil.nombreUsuario;
                a.Email = usuarioPerfil.email;
                a.Telefono = usuarioPerfil.telefono;
                a.Direccion = usuarioPerfil.direccion;
                c.NombreRepresentante = usuarioPerfil.nombreRepresentante;
                c.ApellidoRepresentante = usuarioPerfil.apellidoRepresentante;
                _context.Usuario.Add(a);
                _context.SaveChanges();
                _context.Comercio.Add(c);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;


            }
        }

        public List<ReadAccounts> GetAccountsUser(int userId)
        {
            var query = (   from acc in _context.Cuenta
                            from t in _context.TipoCuenta
                            from b in _context.Banco
                            where
                            acc.IdTipoCuenta == t.IdTipoCuenta &&
                            acc.IdBanco == b.IdBanco &&
                            acc.IdUsuario == userId
                            select new ReadAccounts
                            {
                                banco = b.Nombre,
                                idCuenta = acc.IdCuenta,
                                tipo = t.Descripcion,
                                cuenta = acc.NumeroCuenta
                            }
                        ).OrderBy(p=>p.banco).ToList();

            return query;
        }

        public ReadOperationAccount GetBalance(int usuarioId, int cuentaId)
        {
            List<OperacionCuenta> cuenta = _context.OperacionCuenta.Where(p => p.IdCuenta == cuentaId && p.IdUsuarioReceptor == usuarioId).ToList();
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
                FkIdCuenta = cuentaId,
                FkIdUsuarioReceptor = usuarioId,
                readOperations = reads.ToArray()
            };
            return readOperationAccount;
        }

        public CreatePayment SolicitarPago(string users,
                                           double montog,
                                           string userr)
        {
            
            int referencia = (_context.Pago.Count() + 1)*1007;
            var usuarios = _context.Usuario.FirstOrDefault(src => src.Usuario1 == users);
            var usuarior = _context.Usuario.FirstOrDefault(src => src.Usuario1 == userr);
            
                _context.Pago.Add(
                    new Pago { 
                        IdPago = _context.Pago.Count() + 1,
                        FechaSolicitud = DateTime.Now,
                        Monto = (decimal)montog, 
                        Estatus = "En proceso",
                        Referencia = ""+referencia+"",
                        IdUsuarioSolicitante = usuarios.IdUsuario,
                        IdUsuarioReceptor = usuarior.IdUsuario}
                    );

            _context.SaveChanges();

            CreatePayment payment = new CreatePayment(){
                FechaSolicitud = DateTime.Now,
                Monto = (decimal)montog, 
                EstatusPago = "En proceso",
                Referencia = ""+referencia+"",
                FkIdUsuarioSolicitante = usuarios.IdUsuario,
                FkIdUsuarioReceptor = usuarior.IdUsuario,
                UsuarioReceptor = userr,
                UsuarioSolicitante = users
            };

            return payment;
        }

        public List<ReadOperationReintegro> GetReintegros(int usuarioId)
        {
            var query = (   from o in _context.OperacionCuenta
                            from u in _context.Usuario
                            from usol in _context.Usuario
                            where
                            o.IdUsuarioReceptor == u.IdUsuario &&
                            u.IdUsuario == usuarioId &&
                            o.IdCuenta == usol.IdUsuario &&
                            o.estatus == 1
                            select new ReadOperationReintegro
                            {
                                Referencia = o.Referencia,
                                Estatus = o.estatus, 
                                Fecha = o.Fecha,
                                UsuarioSolicitante = usol.Usuario1,
                            }
                        ).OrderBy(p=>p.Fecha).ToList();

            return query;
        }

        public bool ActualizarEstatusReintegro(string refreintegro, 
                                                    string newestatus)
        {
            var id_reintegro = _context.OperacionCuenta.Where(src => src.Referencia.Equals(refreintegro));
            
            if (id_reintegro != null) 
            {
                var reintegro = id_reintegro.FirstOrDefault(src => src.operacion == false);
                if (newestatus == "ACEPTAR") {
                    reintegro.estatus = 2;
                    reintegro.operacion = !reintegro.operacion;
                } else if (newestatus == "DENEGAR"){
                    reintegro.estatus = 3;
                } else{
                return false;
                };
                
                var afectado = id_reintegro.FirstOrDefault(src => src.operacion == true);
                if (newestatus == "ACEPTAR") {
                    afectado.estatus = 2;
                    afectado.operacion = !afectado.operacion;
                } else if (newestatus == "DENEGAR"){
                    afectado.estatus = 3;
                } else{
                return false;
                };
                
                _context.Add(afectado);
                _context.Add(reintegro);
                _context.SaveChanges();
                return true;
            }
           
            return false;
        }
    }
}
