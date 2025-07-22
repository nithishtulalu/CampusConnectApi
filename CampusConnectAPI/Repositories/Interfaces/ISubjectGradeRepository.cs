using CampusConnectAPI.DTOs.SubGrade;

namespace CampusConnectAPI.Repositories.Interfaces
{
    public interface ISubjectGradeRepository
    {
        Task<List<SubjectResponseDto>> GetAllSubjectsAsync();
        Task<SubjectResponseDto> AddSubjectAsync(CreateSubjectDto dto);

        Task<List<GradeResponseDto>> GetGradesForUserAsync(Guid userId);
        Task<GradeResponseDto> SubmitGradeAsync(SubmitGradeDto dto);

    }
}
