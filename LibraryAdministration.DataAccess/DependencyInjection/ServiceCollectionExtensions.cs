﻿using LibraryAdministration.DataAccess.Repositories;
using LibraryAdministration.DataAccess.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryAdministration.DataAccess.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDataAccess(this IServiceCollection services)
        {
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
