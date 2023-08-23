using EMK.BankApp.Web.Data.Entities;
using EMK.BankApp.Web.Models;
using System.Collections.Generic;

namespace EMK.BankApp.Web.Mapping
{
    public interface IApplicationUserMapping
    {
        List<UserListModel> MapToListOfUserList(List<ApplicationUser> users);

        UserListModel MapToUserList(ApplicationUser user);
    }
}
