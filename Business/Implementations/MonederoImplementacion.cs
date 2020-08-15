﻿using ApiRestDesarrollo.Business.Interface;
using ApiRestDesarrollo.Controllers;
using ApiRestDesarrollo.Dtos.Account;
using ApiRestDesarrollo.Dtos.Operation;
using ApiRestDesarrollo.Dtos.Payment;
using ApiRestDesarrollo.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Business.Implementations
{
    public class MonederoImplementacion:IMonedero
    {
        private readonly postgresContext _context;
        private readonly IMapper _mapper;
        public MonederoImplementacion(postgresContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AddBalance(CreateOperacion createOperacion)
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
                    operacion = true,
                    IdUsuarioReceptor = createOperacion.idUSuario,
                    IdOperacionCuenta = (refid+1) * 135,
                    Referencia = "5789"+ refid * 135,
                    estatus = 0
                };
                _context.Add(operacionCuenta);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AddCuenta(CreateCuenta create)
        {
            var idBanco = _context.Banco.FirstOrDefault(p => p.Nombre.Contains(create.Banco));
            var idTipo = _context.TipoCuenta.FirstOrDefault(p => p.Descripcion.Contains(create.tipo));
            var usuario = _context.Usuario.FirstOrDefault(p => p.IdUsuario == create.IdUsuario);
            var a = _context.Cuenta.Count();
            if (idBanco == null || idTipo == null || usuario == null) 
            { 
                return false; 
            }
            Cuenta cuenta = new Cuenta()
            {
                IdUsuario = create.IdUsuario,
                IdBanco = idBanco.IdBanco,
                IdTipoCuenta = idTipo.IdTipoCuenta,
                NumeroCuenta = create.Cuenta,
                IdCuenta = _context.Cuenta.Count() * 135
            };
            _context.Add(cuenta);
            _context.saveChanges();
            return true;
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

        public ReadOperationAccount GetBalanceByEmail(string email)
        {
            var query = (from usu in _context.Usuario
                         from c in _context.Cuenta
                         from oc in _context.OperacionCuenta
                         where 
                         oc.IdUsuarioReceptor == usu.IdUsuario &&
                         usu.Email.Contains(email)
                         select oc
                        ).ToList().OrderBy(p => p.Fecha);
            ReadOperationAccount readOperationAccount = new ReadOperationAccount();
            if (query != null) 
            { 
                List<ReadOperation> reads = new List<ReadOperation>();
                decimal saldo = 0;

                foreach (var item in query)
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
                readOperationAccount.Monto = saldo;
                readOperationAccount.FkIdCuenta = query.FirstOrDefault().IdCuenta;
                readOperationAccount.FkIdUsuarioReceptor = query.FirstOrDefault().IdUsuarioReceptor;
                readOperationAccount.readOperations = reads.Take(4).ToArray();
            }
            return readOperationAccount;
        }

        public bool transferencia(PagoDtos pago)
        {
            var saldo = GetBalance(pago.IdUsuario);
            if (saldo != null && saldo.Monto > pago.monto) {
                var UsuarioReceptor = _context.Usuario.FirstOrDefault(p=>p.Usuario1 == pago.Usuario);
                int refid = _context.OperacionCuenta.Count();
                DateTime fecha = DateTime.Now;
                TimeSpan hora = TimeSpan.Parse(fecha.Hour + ":" + fecha.Minute);
                OperacionCuenta operacionCuentaReceptor = new OperacionCuenta()
                {
                    Fecha = fecha,
                    Hora = hora,
                    IdCuenta = 1,
                    Monto = pago.monto,
                    operacion = true,
                    IdUsuarioReceptor = UsuarioReceptor.IdUsuario,
                    IdOperacionCuenta = (refid+1) * 135,
                    Referencia = "3789" + refid * 135,
                    estatus = 0
                };
                OperacionCuenta operacionCuentaEnvia = new OperacionCuenta()
                {
                    Fecha = fecha,
                    Hora = hora,
                    IdCuenta = 1,
                    Monto = pago.monto,
                    operacion = false,
                    IdUsuarioReceptor = pago.IdUsuario,
                    IdOperacionCuenta = (refid + 2) * 135,
                    Referencia = "3789" + refid * 135,
                    estatus = 0
                };
                _context.Add(operacionCuentaReceptor);
                _context.Add(operacionCuentaEnvia);
                _context.saveChanges();
                return true;
            }
            return false;
        }

        private bool Payment(PagoDtos pago, string reference)
        {
            var saldo = GetBalance(pago.IdUsuario);
            if (saldo != null && saldo.Monto > pago.monto)
            {
                var UsuarioReceptor = _context.Usuario.FirstOrDefault(p => p.Usuario1 == pago.Usuario);
                int refid = _context.OperacionCuenta.Count();
                var parametro = _context.Parametro.FirstOrDefault(p=> p.IdParametro == 0);
                DateTime fecha = DateTime.Now;
                TimeSpan hora = TimeSpan.Parse(fecha.Hour + ":" + fecha.Minute);
                decimal comision = pago.monto * 0.10m;
                decimal total = pago.monto - comision; 
                OperacionCuenta operacionCuentaReceptor = new OperacionCuenta()
                {
                    Fecha = fecha,
                    Hora = hora,
                    IdCuenta = 1,
                    Monto = total,
                    operacion = true,
                    IdUsuarioReceptor = UsuarioReceptor.IdUsuario,
                    IdOperacionCuenta = (refid + 1) * 135,
                    Referencia = reference + refid * 135,
                    estatus = 0
                };
                OperacionCuenta operacionCuentaEnvia = new OperacionCuenta()
                {
                    Fecha = fecha,
                    Hora = hora,
                    IdCuenta = 1,
                    Monto = pago.monto,
                    operacion = false,
                    IdUsuarioReceptor = pago.IdUsuario,
                    IdOperacionCuenta = (refid + 2) * 135,
                    Referencia = reference + refid * 135,
                    estatus = 0
                };
                OperacionCuenta operacionCuentaReceptor1 = new OperacionCuenta()
                {
                    Fecha = fecha,
                    Hora = hora,
                    IdCuenta = 1,
                    Monto = comision,
                    operacion = true,
                    IdUsuarioReceptor = UsuarioReceptor.IdUsuario,
                    IdOperacionCuenta = (refid + 3) * 135,
                    Referencia = reference + refid * 135,
                    estatus = 10
                };
                _context.Add(operacionCuentaReceptor1);
                _context.Add(operacionCuentaReceptor);
                _context.Add(operacionCuentaEnvia);
                _context.saveChanges();
                return true;
            }
            return false;
        }

        public List<PagoSolicitud> pagoSolicitud(int IdUsuario)
        {
            var solicitudes = (from pago in _context.Pago
                               from usu in _context.Usuario
                               where
                               pago.IdUsuarioSolicitante == usu.IdUsuario &&
                               pago.IdUsuarioSolicitante == IdUsuario
                               select new PagoSolicitud
                               {
                                   Estatus = pago.Estatus,
                                   FechaSolicitud = pago.FechaSolicitud,
                                   Monto = pago.Monto,
                                   Referencia = pago.Referencia,
                                   Solicitante = usu.Usuario1,
                                   IdPago = pago.IdPago
                               }).OrderBy(p=>p.Estatus.Contains("en proceso")).ToList();
            return solicitudes;
        }

        public bool pagoTienda(PagoTiendaDtos pago)
        {
            var PagoFactura = _context.Pago.FirstOrDefault(p=>p.IdPago == pago.IdPago);
            if (PagoFactura != null) 
            {
                var transferecia = Payment(new PagoDtos { Cuenta = pago.Cuenta, IdUsuario = pago.IdUsuario, monto = pago.monto, Usuario = pago.Usuario }, "2789");
                if (transferecia) {
                    PagoFactura.Estatus = "pagado";
                    //_context.Add(PagoFactura);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            } //agregar codigo para comercio 2789
            return false;
        }

        public bool paypal(PagoDtos pagoPaypal)
        {
            var persona = _context.Cuenta.FirstOrDefault(p=> p.NumeroCuenta.Contains(pagoPaypal.Cuenta) && p.IdUsuario == pagoPaypal.IdUsuario);
            if (persona != null)
            {
                var UsuarioReceptor = _context.Usuario.FirstOrDefault(p => p.Usuario1 == pagoPaypal.Usuario);
                int refid = _context.OperacionCuenta.Count();
                DateTime fecha = DateTime.Now;
                TimeSpan hora = TimeSpan.Parse(fecha.Hour + ":" + fecha.Minute);
                OperacionCuenta operacionCuentaReceptor = new OperacionCuenta()
                {
                    Fecha = fecha,
                    Hora = hora,
                    IdCuenta = 1,
                    Monto = pagoPaypal.monto,
                    operacion = true,
                    IdUsuarioReceptor = UsuarioReceptor.IdUsuario,
                    IdOperacionCuenta = (refid + 3) * 135,
                    Referencia = "4789" + refid * 135,
                    estatus = 0
                };
                OperacionCuenta operacionCuentaEnvia = new OperacionCuenta()
                {
                    Fecha = fecha,
                    Hora = hora,
                    IdCuenta = persona.IdCuenta,
                    Monto = pagoPaypal.monto,
                    operacion = true,
                    IdUsuarioReceptor = pagoPaypal.IdUsuario,
                    IdOperacionCuenta = (refid + 1)* 135,
                    Referencia = "4789" + refid * 135,
                    estatus = 0
                };
                OperacionCuenta operacionCuentaEnvia2 = new OperacionCuenta()
                {
                    Fecha = fecha,
                    Hora = hora,
                    IdCuenta = persona.IdCuenta,
                    Monto = pagoPaypal.monto,
                    operacion = false,
                    IdUsuarioReceptor = pagoPaypal.IdUsuario,
                    IdOperacionCuenta = (refid + 2) * 135,
                    Referencia = "4789" + refid * 135,
                    estatus = 0
                };
                _context.Add(operacionCuentaReceptor);
                _context.Add(operacionCuentaEnvia);
                _context.Add(operacionCuentaEnvia2);
                _context.saveChanges();
                return true;
            }
                return false;
        }
        
        public bool reintegro(ReintegroDto reintegroDto)
        {
            var tipoOperacion = _context.OperacionCuenta.Where(p => p.Referencia.Equals(reintegroDto.referencia) && p.estatus == 0);
            
            if (tipoOperacion != null && tipoOperacion.FirstOrDefault(p=>p.IdUsuarioReceptor == reintegroDto.idUser).operacion == false) 
            {
                int refid = _context.OperacionCuenta.Count();
                var reintegro = tipoOperacion.FirstOrDefault(p => p.operacion == false);
                reintegro.IdOperacionCuenta = (refid+2) * 135;
                reintegro.Referencia = "1789" + refid * 135;
                reintegro.operacion = false;
                reintegro.estatus = 1;
                var afectado = tipoOperacion.FirstOrDefault(p => p.operacion == true);
                afectado.IdOperacionCuenta = (refid + 1) * 135;
                afectado.Referencia = "1789" + refid * 135;
                afectado.operacion = true;
                afectado.estatus = 1;
                _context.Add(afectado);
                _context.Add(reintegro);
                _context.SaveChanges();
                return true;
            }
           
            return false;
        }
    }
}
