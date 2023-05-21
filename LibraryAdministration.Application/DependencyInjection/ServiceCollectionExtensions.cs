using Microsoft.Extensions.DependencyInjection;
using LibraryAdministration.Application.Services;
using LibraryAdministration.Application.Services.Abstractions;
using LibraryAdministration.DataAccess.DependencyInjection;
using LibraryAdministration.Application.Mappings;

namespace LibraryAdministration.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.RegisterDataAccess();
        }
    }
}
