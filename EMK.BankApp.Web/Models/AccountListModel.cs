namespace EMK.BankApp.Web.Models
{
    public class AccountListModel
    {
        public int ID { get; set; }
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
        public int ApplicationUserID { get; set; }
    }
}
