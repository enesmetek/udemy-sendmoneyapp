using EMK.BankApp.Web.Data.Context;
using EMK.BankApp.Web.Data.Entities;
using EMK.BankApp.Web.Data.Interfaces;
using EMK.BankApp.Web.Data.Repository;
using EMK.BankApp.Web.Mapping;
using EMK.BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EMK.BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        //private readonly BankContext _context;
        //private readonly IApplicationUserRepository _userRepository;
        //private readonly IApplicationUserMapping _userMapping;
        //private readonly IAccountRepository _accountRepository;
        //private readonly IAccountMapping _accountMapping;

        //public AccountController(BankContext context, IApplicationUserRepository userRepository, IApplicationUserMapping userMapping, IAccountRepository accountRepository, IAccountMapping accountMapping)
        //{
        //    _context = context;
        //    _userRepository = userRepository;
        //    _userMapping = userMapping;
        //    _accountRepository = accountRepository;
        //    _accountMapping = accountMapping;
        //}

        private readonly IGenericRepository<Account> _accountRepository;
        private readonly IGenericRepository<ApplicationUser> _userRepository;

        public AccountController(IGenericRepository<Account> accountRepository, IGenericRepository<ApplicationUser> userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

        public IActionResult Create(int id)
        {
            var userInfo = _userRepository.GetByID(id);
            return View(new UserListModel
            {
                ID = userInfo.ID, 
                Name = userInfo.Name,
                Surname = userInfo.Surname
            });
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model) 
        {
            _accountRepository.Create(new Account
            {
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                ApplicationUserID = model.ApplicationUserID,
            });        
           
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetByUserId(int userID)
        {
            var query = _accountRepository.GetQueryable();
            var accounts = query.Where(x => x.ApplicationUserID == userID).ToList();

            var user = _userRepository.GetByID(userID);

            var list = new List<AccountListModel>();

            ViewBag.FullName = user.Name + " " + user.Surname;

            foreach (var account in accounts)
            {
                list.Add(new AccountListModel
                {
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance,
                    ApplicationUserID = account.ApplicationUserID,
                    ID = account.ID,
                });
            }

            return View(list);
        }

        [HttpGet]
        public IActionResult SendMoney(int accountID)
        {
            var query = _accountRepository.GetQueryable();
            var accounts = query.Where(x => x.ID != accountID).ToList();
            var list = new List<AccountListModel>();

            ViewBag.SenderID = accountID;

            foreach (var account in accounts)
            {
                list.Add(new()
                {
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance,
                    ApplicationUserID = account.ApplicationUserID,
                    ID = account.ID,
                });
                
            }
            return View(list);
        }
    }
}
