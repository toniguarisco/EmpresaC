using ApiRestDesarrollo.Business.Interface;
using ApiRestDesarrollo.Dtos.Operation;
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
                fecha = item.Fecha,
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
                        fecha = item.Fecha,
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
    }
}
