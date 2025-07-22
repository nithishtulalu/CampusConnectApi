namespace CampusConnectAPI.DTOs.Attendance
{
    public class AttendanceResponseDto
    {
        public Guid AttendanceId { get; set; }
        public string SubjectName {  get; set; }
        public DateTime Date {  get; set; }
        public  bool Status {  get; set; }
    }
}
