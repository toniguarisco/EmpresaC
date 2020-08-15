﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Dtos;
using ApiRestDesarrollo.Dtos.User;
using ApiRestDesarrollo.Dtos.Account;
using ApiRestDesarrollo.Dtos.Operation;
using ApiRestDesarrollo.Dtos.Card;

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

        bool CreateOperation(CreateOperacion operacion);

        bool AddCard(CreateCard card);

        List<ReadCard> GetUserCard(int IdUser);

        //bool RetiroCommerce()

        UsuarioRead GetUserById(int IdUser);

        List<ReadUserPersona> AdminGetUsersPersona(int IdTipoPersona);

        List<ReadUserCommerce> AdminGetUsersCommerce(int IdTipoComercio);

    }
}
