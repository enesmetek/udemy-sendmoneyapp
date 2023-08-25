namespace EMK.BankApp.Web.Models
{
    public class SendMoneyModel
    {
        public int SenderID { get; set; }
        public int AccountID { get; set; }
        public decimal Amount { get; set; }
    }
}
