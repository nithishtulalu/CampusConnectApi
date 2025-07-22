using CampusConnectAPI.DTOs.Attendance;

namespace CampusConnectAPI.Services.Interfaces
{
    public interface IAttendanceService
    {
        Task<AttendanceResponseDto> MarkAttendanceAsync(MarkAttendanceDto dto);
        Task<List<AttendanceResponseDto>> GetAllAttendancesAsync(Guid userId);
    }
}
