using CampusConnectAPI.DTOs.Attendance;
using CampusConnectAPI.Repositories.Interfaces;
using CampusConnectAPI.Services.Interfaces;

namespace CampusConnectAPI.Services.implementation
{
    public class AttendanceService:IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

       public async  Task<AttendanceResponseDto> MarkAttendanceAsync(MarkAttendanceDto dto)=>
            await _attendanceRepository.MarkAttendanceAsync(dto);
        public async Task<List<AttendanceResponseDto>> GetAllAttendancesAsync(Guid userId)=>
            await _attendanceRepository.GetAllAttendancesAsync(userId);
    }
}
