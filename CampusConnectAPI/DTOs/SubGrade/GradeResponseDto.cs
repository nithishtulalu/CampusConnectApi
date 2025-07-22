namespace CampusConnectAPI.DTOs.SubGrade
{
    public class GradeResponseDto
    {
        public Guid GradeId { get; set; }
        public string CourseName {  get; set; }
        public string SubjectName { get; set; }
        public int Marks {  get; set; }
        public string GradeValue {  get; set; }
        public DateTime GradedOn { get; set; }
    }
}
