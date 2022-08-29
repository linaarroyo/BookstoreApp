using Blazored.LocalStorage;
using BookstoreApp.Blazor.Server.UI.Services.Base;

namespace BookstoreApp.Blazor.Server.UI.Services
{
    public class AuthorService : BaseHttpService, IAuthorService
    {
        private readonly IClient client;

        public AuthorService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            this.client = client;
        }

        public async Task<Response<int>> CreateAsync(AuthorCreateDto author)
        {
            Response<int> response = new() { Success = true};

            try
            {
                await GetBearerToken();
                await client.AuthorsPOSTAsync(author);
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
                await client.AuthorsDELETEAsync(id);
            }
            catch (ApiException exception)
            {

                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }

        public async Task<Response<int>> EditAsync(int id, AuthorUpdateDto author)
        {
            Response<int> response = new() { Success = true };

            try
            {
                await GetBearerToken();
                await client.AuthorsPUTAsync(id, author);
            }
            catch (ApiException exception)
            {

                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }

        public async Task<Response<AuthorDetailsDto>> GetAsync(int id)
        {
            Response<AuthorDetailsDto> response;

            try
            {
                await GetBearerToken();
                var data = await client.AuthorsGETAsync(id);
                response = new Response<AuthorDetailsDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException exceptions)
            {
                response = ConvertApiExceptions<AuthorDetailsDto>(exceptions);
            }

            return response;
        }

        public async Task<Response<List<AuthorReadOnlyDto>>> GetAsync()
        {
            Response<List<AuthorReadOnlyDto>> response;

            try
            {
                await GetBearerToken();
                var data = await client.AuthorsAllAsync();
                response = new Response<List<AuthorReadOnlyDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException exceptions)
            {
                response = ConvertApiExceptions<List<AuthorReadOnlyDto>>(exceptions);
            }

            return response;
        }

    }
}
