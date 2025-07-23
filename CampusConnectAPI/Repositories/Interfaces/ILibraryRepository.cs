using CampusConnectAPI.DTOs.Library;

namespace CampusConnectAPI.Repositories.Interfaces
{
    public interface ILibraryRepository
    {
        Task<List<BookResponseDto>> GetAvailableBooksAsync();
        Task<BorrowHistoryDto> BorrowBookAsync(BorrowRequestDto dto);
        Task<List<BorrowHistoryDto>> GetBorrowHistoryAsync(Guid userId);
    }
}
