using EMK.BankApp.Web.Data.Entities;
using EMK.BankApp.Web.Models;
using System.Collections.Generic;

namespace EMK.BankApp.Web.Mapping
{
    public interface IAccountMapping
    {
        Account MapToAccount(AccountCreateModel accountCreateModel);
    }
}
