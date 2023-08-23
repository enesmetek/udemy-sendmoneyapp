using EMK.BankApp.Web.Data.Context;
using EMK.BankApp.Web.Data.Entities;
using EMK.BankApp.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace EMK.BankApp.Web.Mapping
{
    public class AccountMapping : IAccountMapping
    {
        private readonly BankContext _context;

        public AccountMapping(BankContext context)
        {
            _context = context;
        }

        public Account MapToAccount(AccountCreateModel accountCreateModel)
        {
            return new Account
            {
                Balance = accountCreateModel.Balance,
                AccountNumber = accountCreateModel.AccountNumber,
                ApplicationUserID = accountCreateModel.ApplicationUserID,
            };
        }
    }
}
