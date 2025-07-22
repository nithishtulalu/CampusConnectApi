namespace CampusConnectAPI.DTOs.FeesTransactions
{
    public class TransactionRequestDto
    {
        public Guid FeeId { get; set; }
        public int AmountPaid {  get; set; }
        public string PaymentMethod {  get; set; }

    }
}
