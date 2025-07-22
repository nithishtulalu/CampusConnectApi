namespace CampusConnectAPI.DTOs.CourseEnrollment
{
    public class EnrollmentResponseDto
    {
        public Guid EnrollmentId { get; set; }
        public string CourseName {  get; set; }
        public DateTime EnrolledOn { get; set; }
    }
}
