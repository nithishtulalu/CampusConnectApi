using CampusConnectAPI.DTOs.Attendance;

namespace CampusConnectAPI.Repositories.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<AttendanceResponseDto> MarkAttendanceAsync(MarkAttendanceDto dto);
        Task<List<AttendanceResponseDto>> GetAllAttendancesAsync(Guid userId);
    }
}
