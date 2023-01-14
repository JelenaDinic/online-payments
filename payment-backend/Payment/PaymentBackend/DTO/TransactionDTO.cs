namespace PaymentBackend.DTO
{
    public class TransactionDTO
    {
        public int UserId { get; set; }
        public int Amount { get; set; }
        public string RecipientEmail { get; set; }
    }
}
