namespace CampusConnectAPI.DTOs.FeesTransactions
{
    public class StudentPaymnetRequestDto
    {
        public Guid UserId { get; set; }
        public int AmountPaid { get; set; }
        public string PaymentMethod { get; set; }
    }
}
