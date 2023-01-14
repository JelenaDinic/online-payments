namespace PaymentBackend.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int User { get; set; }
        public string RecipientEmail { get; set; }
        public DateTime DateTime { get; set; }

    }
}
