namespace CampusConnectAPI.DTOs.FeedBacks
{
    public class FeedbackRequestDto
    {
        public Guid UserId { get; set; }
        public  int Rating { get; set; }
        public string Comments {  get; set; }
    }
}
