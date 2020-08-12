using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestDesarrollo.Dtos.User;

namespace ApiRestDesarrollo.Business.Interface
{
    public interface IPortal
    {
        bool UpdateUserPerson(UpdateUserPersona person);

        bool UpdateUserCommerce(UpdateUserCommerce commerce);
    }
}
