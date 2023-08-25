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
    public class HomeController : Controller
    {
        //private readonly BankContext _context;
        //private readonly IApplicationUserRepository _userRepository;
        private readonly IApplicationUserMapping _userMapping;

        //public HomeController(BankContext context, IApplicationUserRepository userRepository, IApplicationUserMapping userMapping)
        //{
        //    _context = context;
        //    _userRepository = userRepository;
        //    _userMapping = userMapping;
        //}

        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IApplicationUserMapping userMapping, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userMapping = userMapping;
        }

        public IActionResult Index()
        {
            return View(_userMapping.MapToListOfUserList(_unitOfWork.GetRepository<ApplicationUser>().GetAll()));
        }
    }
}
