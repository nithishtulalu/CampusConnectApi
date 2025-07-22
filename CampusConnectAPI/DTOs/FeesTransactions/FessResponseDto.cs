namespace CampusConnectAPI.DTOs.FeesTransactions
{
    public class FessResponseDto
    {
        public Guid feeId {  get; set; }
        public int AmountDue{  get; set; }
        public DateTime DueDate { get; set; }
        public int TotalPaid {  get; set; }
        public int RemainingDue=>AmountDue - TotalPaid;
    }
}
