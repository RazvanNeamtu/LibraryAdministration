using Microsoft.Extensions.DependencyInjection;
using LibraryAdministration.Application.Services;
using LibraryAdministration.Application.Services.Abstractions;
using LibraryAdministration.DataAccess.DependencyInjection;

namespace LibraryAdministration.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ITokenService, TokenService>();
            services.RegisterDataAccess();
        }
    }
}
