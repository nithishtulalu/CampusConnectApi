using System.ComponentModel.DataAnnotations;

namespace CampusConnectAPI.Models
{
    public class Transaction
    {
        [Key]
        public Guid TransactionId { get; set; }
        public Guid FeeId { get; set; }
        public int AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }

        public Fee Fee { get; set; }
    }
}
