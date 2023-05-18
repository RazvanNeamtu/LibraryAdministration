namespace LibraryAdministration.Application.Services.Abstractions
{
    public interface IAuthService
    {
        Task<(bool, string)> RegisterUser(string username, string password, string email);
        Task<(string, string, string)> Login(string email, string password);
    }
}
