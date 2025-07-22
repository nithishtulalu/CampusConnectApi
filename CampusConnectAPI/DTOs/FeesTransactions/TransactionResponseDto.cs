namespace CampusConnectAPI.DTOs.FeesTransactions
{
    public class TransactionResponseDto
    {
        public Guid TransactionId { get; set; }
        public int AmountPaid { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
