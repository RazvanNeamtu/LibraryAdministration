﻿using LibraryAdministration.DataAccess.Context;
using LibraryAdministration.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace LibraryAdministration.DataAccess.Repositories
{
    public class UserRepository : Repository<IdentityUser>, IUserRepository
    {
        private readonly ApplicationDbContext _applicationContext;
        public UserRepository(ApplicationDbContext usersContext) : base(usersContext)
        {
            _applicationContext = usersContext;
        }

        public Task Save()
        {
            return _applicationContext.SaveChangesAsync();
        }

        public void Update(IdentityUser user)
        {
            _applicationContext.Update(user);
        }
    }
}
