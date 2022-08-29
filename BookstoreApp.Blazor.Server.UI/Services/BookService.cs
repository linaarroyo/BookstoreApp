using Blazored.LocalStorage;
using BookstoreApp.Blazor.Server.UI.Services.Base;

namespace BookstoreApp.Blazor.Server.UI.Services
{
    public class BookService : BaseHttpService, IBookService
    {
        private readonly IClient client;

        public BookService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            this.client = client;
        }

        public async Task<Response<int>> CreateAsync(BookCreateDto book)
        {
            Response<int> response = new() { Success = true};

            try
            {
                await GetBearerToken();
                await client.BooksPOSTAsync(book);
            }
            catch (ApiException exception)
            {

                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }

        public async Task<Response<int>> DeleteAsync(int id)
        {
            Response<int> response = new() { Success = true };

            try
            {
                await GetBearerToken();
                await client.BooksDELETEAsync(id);
            }
            catch (ApiException exception)
            {

                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }

        public async Task<Response<int>> EditAsync(int id, BookUpdateDto book)
        {
            Response<int> response = new() { Success = true };

            try
            {
                await GetBearerToken();
                await client.BooksPUTAsync(id, book);
            }
            catch (ApiException exception)
            {

                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }

        public async Task<Response<BookDetailsDto>> GetAsync(int id)
        {
            Response<BookDetailsDto> response;

            try
            {
                await GetBearerToken();
                var data = await client.BooksGETAsync(id);
                response = new Response<BookDetailsDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException exceptions)
            {
                response = ConvertApiExceptions<BookDetailsDto>(exceptions);
            }

            return response;
        }

        public async Task<Response<List<BookReadOnlyDto>>> GetAsync()
        {
            Response<List<BookReadOnlyDto>> response;

            try
            {
                await GetBearerToken();
                var data = await client.BooksAllAsync();
                response = new Response<List<BookReadOnlyDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException exceptions)
            {
                response = ConvertApiExceptions<List<BookReadOnlyDto>>(exceptions);
            }

            return response;
        }

    }
}
