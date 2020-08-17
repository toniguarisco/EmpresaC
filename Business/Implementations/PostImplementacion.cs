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
           
            var comercio = (from usu in _context.Usuario
                            from c in _context.Comercio
                            where
                            usu.IdUsuario == c.IdUsuario &&
                            usu.IdUsuario == usuarioPerfil.idUsuario
                            select new
                            {
                                comercio = c,
                                usuario = usu
                            }).FirstOrDefault();

            if ((comercio != null))
            {
                if (!String.IsNullOrEmpty(usuarioPerfil.direccion))
                {
                    comercio.usuario.Direccion = usuarioPerfil.direccion;
                }
                if (!String.IsNullOrEmpty(usuarioPerfil.email))
                {
                    comercio.usuario.Email = usuarioPerfil.email;
                }
                if (!String.IsNullOrEmpty(usuarioPerfil.nombreUsuario))
                {
                    comercio.usuario.Usuario1 = usuarioPerfil.nombreUsuario;
                }
                if (!String.IsNullOrEmpty(usuarioPerfil.telefono))
                {
                    comercio.usuario.Telefono = usuarioPerfil.telefono;
                }
                if (!String.IsNullOrEmpty(usuarioPerfil.apellidoRepresentante))
                {
                    comercio.comercio.ApellidoRepresentante = usuarioPerfil.apellidoRepresentante;
                }
                if (!String.IsNullOrEmpty(usuarioPerfil.nombreRepresentante))
                {
                    comercio.comercio.NombreRepresentante = usuarioPerfil.nombreRepresentante;
                }
                _context.SaveChanges();

               
                return true;
            }
            return false;
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

        public ReadOperationAccount GetBalance(int usuarioId)
        {
            List<OperacionCuenta> cuenta = _context.OperacionCuenta.Where(p => p.IdUsuarioReceptor == usuarioId && p.estatus != 1 && p.estatus != 3 && p.estatus !=10).ToList();
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

        public CreatePayment SolicitarPago(SolicitarPago pago)
        {
            
            int referencia = (_context.Pago.Count() + 1)*1007;
            var usuarios = _context.Usuario.FirstOrDefault(src => src.Usuario1 == pago.users);
            var usuarior = _context.Usuario.FirstOrDefault(src => src.Usuario1 == pago.userr);
            
                _context.Pago.Add(
                    new Pago { 
                        IdPago = _context.Pago.Count() + 1,
                        FechaSolicitud = DateTime.Now,
                        Monto = (decimal)pago.montog, 
                        Estatus = "En proceso",
                        Referencia = ""+referencia+"",
                        IdUsuarioSolicitante = usuarios.IdUsuario,
                        IdUsuarioReceptor = usuarior.IdUsuario}
                    );

            _context.SaveChanges();

            CreatePayment payment = new CreatePayment(){
                FechaSolicitud = DateTime.Now,
                Monto = (decimal)pago.montog, 
                EstatusPago = "En proceso",
                Referencia = ""+referencia+"",
                FkIdUsuarioSolicitante = usuarios.IdUsuario,
                FkIdUsuarioReceptor = usuarior.IdUsuario,
                UsuarioReceptor = pago.userr,
                UsuarioSolicitante = pago.users
            };

            return payment;
        }

        public List<ReadOperationReintegro> GetReintegros(int usuarioId)
        {
            var query = (from usu in _context.Usuario
                         from op in _context.OperacionCuenta
                         where
                         op.IdUsuarioReceptor == usu.IdUsuario &&
                         op.IdUsuarioReceptor == usuarioId &&
                         op.estatus == 1 &&
                         !op.operacion 
                         select new ReadOperationReintegro
                         {
                             Estatus = op.estatus,
                             Fecha = op.Fecha,
                             Monto = op.Monto,
                             Referencia = op.Referencia,
                             UsuarioSolicitante = usu.Usuario1
                         }).ToList();
            
            return query;
        }

        public DevolverUsuario GetUsuario(int usuarioId)
        {
            

            var query = (from u in _context.Usuario
                         from c in _context.Comercio
                         where
                         u.IdUsuario == c.IdUsuario &&
                         u.IdUsuario == usuarioId 
                         select new DevolverUsuario
                         {                          

                             nombreUsuario=u.Usuario1,
                             email=u.Email,
                             telefono=u.Telefono,
                             direccion=u.Direccion,
                             nombreRepresentante=c.NombreRepresentante,
                             apellidoRepresentante=c.ApellidoRepresentante
                         }
                       ).FirstOrDefault();

            return query;




        }

        public bool ActualizarEstatusReintegro(reintegroId reintegroParametro)
        {
            var id_reintegro = _context.OperacionCuenta.Where(src => src.Referencia.Equals(reintegroParametro.RefReintegro));
            
            if (id_reintegro != null) 
            {
                var reintegro = id_reintegro.FirstOrDefault(src => src.operacion == false);
                if (reintegroParametro.newEstatus== "ACEPTAR") {
                    reintegro.estatus = 2;
                    reintegro.operacion = !reintegro.operacion;
                } else if (reintegroParametro.newEstatus == "DENEGAR"){
                    reintegro.estatus = 3;
                } else{
                return false;
                };
                
                var afectado = id_reintegro.FirstOrDefault(src => src.operacion == true);
                if (reintegroParametro.newEstatus == "ACEPTAR") {
                    afectado.estatus = 2;
                    afectado.operacion = !afectado.operacion;
                } else if (reintegroParametro.newEstatus== "DENEGAR"){
                    afectado.estatus = 3;
                } else{
                return false;
                };
                
                //_context.Add(afectado);
                //_context.Add(reintegro);
                _context.SaveChanges();
                return true;
            }
           
            return false;
        }
    }
}
