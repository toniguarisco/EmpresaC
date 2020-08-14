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

        public List<ReadRefund> GetReintegros(int usuarioId)
        {
            var query = (   from r in _context.Reintegro
                            from u in _context.Usuario
                            from usol in _context.Usuario
                            where
                            r.IdUsuarioReceptor == u.IdUsuario &&
                            u.IdUsuario == usuarioId &&
                            r.IdUsuarioSolicitante == usol.IdUsuario
                            select new ReadRefund
                            {
                                Referencia = r.Referencia,
                                EstatusReintegro = r.Estatus, 
                                FechaSolicitud = r.FechaSolicitud,
                                UsuarioSolicitante = usol.Usuario1,
                            }
                        ).OrderBy(p=>p.FechaSolicitud).ToList();

            return query;
        }

        public bool ActualizarEstatusReintegro(int idreintegro, 
                                                       string newestatus)
        {
            var id_reintegro = _context.Reintegro.FirstOrDefault(src => src.IdReintegro == idreintegro);
            
            if (id_reintegro == null){
                return false;
            }

             id_reintegro.Estatus = newestatus;
             _context.SaveChanges();
            
            return true;
        }
    }
}
