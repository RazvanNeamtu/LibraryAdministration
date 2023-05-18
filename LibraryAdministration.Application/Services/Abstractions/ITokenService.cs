using Microsoft.AspNetCore.Identity;

namespace LibraryAdministration.Application.Services.Abstractions
{
    public interface ITokenService
    {
        string GetToken(IdentityUser user);
    }
}
