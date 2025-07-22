using CampusConnectAPI.DTOs.SubGrade;
using CampusConnectAPI.Repositories.Interfaces;
using CampusConnectAPI.Services.Interfaces;

namespace CampusConnectAPI.Services.implementation
{
    public class SubjectGradeService:ISubjectGradeService
    {
        private readonly ISubjectGradeRepository _repository;
        public SubjectGradeService(ISubjectGradeRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<SubjectResponseDto>> GetAllSubjectsAsync()=>
            await _repository.GetAllSubjectsAsync();

        public async Task<SubjectResponseDto> AddSubjectAsync(CreateSubjectDto dto) =>
             await _repository.AddSubjectAsync(dto);

        public async Task<List<GradeResponseDto>> GetGradesForUserAsync(Guid userId)=>
            await _repository.GetGradesForUserAsync(userId);

        public async Task<GradeResponseDto> SubmitGradeAsync(SubmitGradeDto dto)=>
            await _repository.SubmitGradeAsync(dto);

    }
}
