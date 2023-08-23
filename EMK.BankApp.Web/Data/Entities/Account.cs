namespace EMK.BankApp.Web.Data.Entities
{
    public class Account
    {
        public int ID { get; set; }
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }

        public int ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
