namespace CampusConnectAPI.DTOs.Library
{
    public class BorrowHistoryDto
    {
        public Guid BorrowId { get; set; }
        public string Title {  get; set; }
        public DateTime BorrowDate { get; set; }    
        public DateTime? ReturnDate { get; set; }   

    }
}
