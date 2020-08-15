using ApiRestDesarrollo.Dtos;
using ApiRestDesarrollo.Dtos.Operation;
using ApiRestDesarrollo.Dtos.Payment;
using ApiRestDesarrollo.Dtos.Refund;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDesarrollo.Business.Interface
{
    public interface IPost
    {
        ReadOperationAccount GetBalance(int usuarioId, int cuentaId);
        List<ReadAccounts> GetAccountsUser(int userId);
        CreatePayment SolicitarPago(string users, double montog, string userr);
        List<ReadOperationReintegro> GetReintegros(int usuarioId);
        DevolverUsuario GetUsuario(int usuarioId);
        bool ActualizarEstatusReintegro(string refreintegro, string newestatus);
        bool actualizarPerfil(PerfilModel usuarioPerfil);

    }
}
