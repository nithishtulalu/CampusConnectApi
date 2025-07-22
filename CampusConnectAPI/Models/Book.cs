using System.ComponentModel.DataAnnotations;

namespace CampusConnectAPI.Models
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int AvailableCopies { get; set; }

        public ICollection<BorrowHistory> BorrowHistories { get; set; }
    }
}
