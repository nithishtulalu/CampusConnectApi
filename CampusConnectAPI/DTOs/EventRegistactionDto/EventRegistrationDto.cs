namespace CampusConnectAPI.DTOs.EventRegistactionDto
{
    public class EventRegistrationDto
    {
        public Guid RegistrationId {  get; set; }
        public string EventTitle {  get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}
