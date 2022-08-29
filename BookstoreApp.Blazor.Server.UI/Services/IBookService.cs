using BookstoreApp.Blazor.Server.UI.Services.Base;

namespace BookstoreApp.Blazor.Server.UI.Services
{
    public interface IBookService
    {
        Task<Response<List<BookReadOnlyDto>>> GetAsync();
        Task<Response<int>> CreateAsync(BookCreateDto Book);
        Task<Response<int>> EditAsync(int id, BookUpdateDto Book);
        Task<Response<BookDetailsDto>> GetAsync(int id);
        Task<Response<int>> DeleteAsync(int id);

    }
}