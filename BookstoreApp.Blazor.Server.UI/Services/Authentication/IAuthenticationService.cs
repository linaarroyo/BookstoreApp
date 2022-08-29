using BookstoreApp.Blazor.Server.UI.Services.Base;

namespace BookstoreApp.Blazor.Server.UI.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(LoginUserDto loginModel);
        public Task Logout();
    }


}
