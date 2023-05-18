using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LibraryAdministration.DataAccess.Context
{
    public class UsersContext : IdentityUserContext<IdentityUser>
    {
        private readonly IConfiguration _configuration;
        public UsersContext(DbContextOptions<UsersContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_configuration["ConnectionStrings:DefaultConnectionString"]);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
