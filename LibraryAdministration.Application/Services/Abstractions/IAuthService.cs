using LibraryAdministration.Application.Models;

namespace LibraryAdministration.Application.Services.Abstractions
{
    public interface IAuthService
    {
        Task<(bool, string)> RegisterUser(string username, string password, string email, UserInfoDto userInfo);
        Task<(string, string, string)> LoginByEmail(string email, string password);
        Task<(string, string, string)> LoginByUsername(string username, string password);
    }
}
