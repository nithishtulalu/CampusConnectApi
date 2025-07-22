namespace CampusConnectAPI.DTOs.SubGrade
{
    public class SubmitGradeDto
    {
        public Guid EnrollmentId { get; set; }
        public Guid SubjectId { get; set; }
        public string Grade {  get; set; }
        public int Marks {  get; set; }
        public string GradeValue {  get; set; }
        public DateTime GradeOn { get; set; }


    }
}
