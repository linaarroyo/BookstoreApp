using BookstoreApp.Blazor.Server.UI.Services.Base;

namespace BookstoreApp.Blazor.Server.UI.Services
{
    public interface IAuthorService
    {
        Task<Response<List<AuthorReadOnlyDto>>> GetAsync();
        Task<Response<int>> CreateAsync(AuthorCreateDto author);
        Task<Response<int>> EditAsync(int id, AuthorUpdateDto author);
        Task<Response<AuthorDetailsDto>> GetAsync(int id);
        Task<Response<int>>DeleteAsync(int id);

    }
}