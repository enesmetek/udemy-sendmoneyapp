namespace EMK.BankApp.Web.Models
{
    public class AccountCreateModel
    {
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
        public int ApplicationUserID { get; set; }
    }
}
