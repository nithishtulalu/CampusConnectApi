namespace CampusConnectAPI.DTOs.Attendance
{
    public class MarkAttendanceDto
    {
        public Guid UserId { get; set; }
        public Guid SubjectId { get; set; }
        public DateTime Date { get; set; }
        public bool Status {  get; set; }

    }
}
