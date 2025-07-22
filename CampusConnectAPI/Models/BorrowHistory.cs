using System.ComponentModel.DataAnnotations;

namespace CampusConnectAPI.Models
{
    public class BorrowHistory
    {
        [Key]
        public Guid BorrowId { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }
}
