using CampusConnectAPI.DTOs.SubGrade;

namespace CampusConnectAPI.Services.Interfaces
{
    public interface ISubjectGradeService
    {
        Task<List<SubjectResponseDto>> GetAllSubjectsAsync();
        Task<SubjectResponseDto> AddSubjectAsync(CreateSubjectDto dto);

        Task<List<GradeResponseDto>> GetGradesForUserAsync(Guid userId);
        Task<GradeResponseDto> SubmitGradeAsync(SubmitGradeDto dto);
    }
}
