using EMK.BankApp.Web.Data.Entities;
using EMK.BankApp.Web.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace EMK.BankApp.Web.Mapping
{
    public class ApplicationUserMapping : IApplicationUserMapping
    {
        public List<UserListModel> MapToListOfUserList(List<ApplicationUser> users)
        {
            return users.Select(x => new UserListModel
            {
                ID = x.ID,
                Name = x.Name,
                Surname = x.Surname,
            }).ToList();
        }

        public UserListModel MapToUserList(ApplicationUser user)
        {
            return new UserListModel
            {
                ID = user.ID,
                Name = user.Name,
                Surname = user.Surname,
            };
        }
    }
}
