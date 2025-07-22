using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace CampusConnectAPI.Models
{
    public class Fee
    {
        [Key] 
        public Guid FeeId { get; set; }
        public Guid UserId { get; set; }
        public int AmountDue { get; set; }
        public DateTime DueDate { get; set; }

        public User User { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
