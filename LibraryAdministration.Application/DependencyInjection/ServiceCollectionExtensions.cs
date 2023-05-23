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
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IRentalService, RentalService>();
            
            services.AddAutoMapper(typeof(MappingProfile));

            services.RegisterDataAccess();
        }
    }
}
