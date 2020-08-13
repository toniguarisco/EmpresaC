using ApiRestDesarrollo.Dtos.Account;
using ApiRestDesarrollo.Dtos.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Business.Interface
{
    public interface IMonedero
    {
        ReadOperationAccount GetBalance(int usuarioId);
        List<ReadAccounts> GetAccountsUser(int userId);
        ReadOperationAccount GetBalanceByEmail(string email);
        bool AddBalance(CreateOperacion createOperacion);
        bool AddCuenta(CreateCuenta create);
        bool reintegro(int IdUser, string reference);
    }
}
