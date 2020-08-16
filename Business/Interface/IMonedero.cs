using ApiRestDesarrollo.Controllers;
using ApiRestDesarrollo.Dtos;
using ApiRestDesarrollo.Dtos.Account;
using ApiRestDesarrollo.Dtos.Operation;
using ApiRestDesarrollo.Dtos.Payment;
using ApiRestDesarrollo.Dtos.User;
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
        mensaje AddBalance(CreateOperacion createOperacion);
        mensaje AddCuenta(CreateCuenta create);
        mensaje reintegro(ReintegroDto reintegro);
        mensaje transferencia(PagoDtos pago);
        mensaje paypal(PagoDtos pagoPaypal);
        List<PagoSolicitud> pagoSolicitud(int IdUsuario);
        mensaje pagoTienda(PagoTiendaDtos pago);
        mensaje UpdatePersona(PersonaUpdate persona);
        
    }
}
