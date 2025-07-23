using CampusConnectAPI.DTOs.Library;

namespace CampusConnectAPI.Services.Interfaces
{
    public interface ILibraryService
    {
        Task<List<BookResponseDto>> GetAvailableBooksAsync();
        Task<BorrowHistoryDto> BorrowBookAsync(BorrowRequestDto dto);
        Task<List<BorrowHistoryDto>> GetBorrowHistoryAsync(Guid userId);
    }
}
