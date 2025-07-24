namespace CampusConnectAPI.DTOs.EventRegistactionDto
{
    public class EventResponseDto
    {
        public Guid EventId { get; set; }
        public string Title {  get; set; }
        public string Description {  get; set; }
        public DateTime Date { get; set; }  

    }
}
