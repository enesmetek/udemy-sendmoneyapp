using System.Collections.Generic;

namespace EMK.BankApp.Web.Data.Entities
{
    public class ApplicationUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
