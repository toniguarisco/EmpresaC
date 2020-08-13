﻿using ApiRestDesarrollo.Dtos.Operation;
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
        void AddBalance(int usuarioId, int cuentaId);

    }
}
