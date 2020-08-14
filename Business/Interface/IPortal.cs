using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Dtos.User;
using ApiRestDesarrollo.Dtos.Account;
using ApiRestDesarrollo.Dtos.Operation;

namespace ApiRestDesarrollo.Business.Interface
{
    public interface IPortal
    {
        bool UpdateUserPerson(UpdateUserPersona person);

        bool UpdateUserCommerce(UpdateUserCommerce commerce);

        ReadUserCommerce GetCommerceById(int IdCommerce);

        ReadUserPersona GetPersonById(int IdPerson);

        bool CreateAccount(CreateCuenta cuenta);

        //ReadAccounts GetAccountsById(int IdUser);

        //bool CreateOperation(CreateOperacion operacion);

        //ReadOperation GetOperationListById(int IdUser);



    }
}
