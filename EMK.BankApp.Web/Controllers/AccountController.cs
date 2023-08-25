using EMK.BankApp.Web.Data.Context;
using EMK.BankApp.Web.Data.Entities;
using EMK.BankApp.Web.Data.Interfaces;
using EMK.BankApp.Web.Data.Repository;
using EMK.BankApp.Web.Mapping;
using EMK.BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        //private readonly igenericrepository<account> _accountrepository;
        //private readonly igenericrepository<applicationuser> _userrepository;

        //public accountcontroller(igenericrepository<account> accountrepository, igenericrepository<applicationuser> userrepository)
        //{
        //    _accountrepository = accountrepository;
        //    _userrepository = userrepository;
        //}

        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public IActionResult Create(int id)
        {
            var userInfo = _unitOfWork.GetRepository<ApplicationUser>().GetByID(id);
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
           _unitOfWork.GetRepository<Account>().Create(new Account
            {
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                ApplicationUserID = model.ApplicationUserID,
            });        
           _unitOfWork.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetByUserId(int userID)
        {
            var query = _unitOfWork.GetRepository<Account>().GetQueryable();
            var accounts = query.Where(x => x.ApplicationUserID == userID).ToList();

            var user = _unitOfWork.GetRepository<ApplicationUser>().GetByID(userID);

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
            var query = _unitOfWork.GetRepository<Account>().GetQueryable();
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
            return View(new SelectList(list,"ID","AccountNumber"));
        }

        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel model)
        {
            var senderAccount = _unitOfWork.GetRepository<Account>().GetByID(model.SenderID);

            senderAccount.Balance -= model.Amount;
            _unitOfWork.GetRepository<Account>().Update(senderAccount);

            var account = _unitOfWork.GetRepository<Account>().GetByID(model.AccountID);
            account.Balance += model.Amount;
            _unitOfWork.GetRepository<Account>().Update(account);

            _unitOfWork.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
