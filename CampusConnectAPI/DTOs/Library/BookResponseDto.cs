namespace CampusConnectAPI.DTOs.Library
{
    public class BookResponseDto
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Auther {  get; set; }
        public string ISBN {  get; set; }
        public int AvailableCopies {  get; set; }

    }
}
