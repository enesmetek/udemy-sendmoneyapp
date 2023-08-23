using EMK.BankApp.Web.Data.Context;
using EMK.BankApp.Web.Data.Entities;
using EMK.BankApp.Web.Data.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;

namespace EMK.BankApp.Web.Data.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly BankContext _context;
       
        public ApplicationUserRepository(BankContext context)
        {
            _context = context;
        }
        public List<ApplicationUser> GetAll()
        {
            return _context.ApplicationUsers.ToList();
        }
        public ApplicationUser GetByID(int id)
        {
            return _context.ApplicationUsers.SingleOrDefault(x => x.ID == id);
        }
    }
}
