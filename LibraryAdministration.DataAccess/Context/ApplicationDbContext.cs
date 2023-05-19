using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LibraryAdministration.DataAccess.Entities;

namespace LibraryAdministration.DataAccess.Context
{
    public class ApplicationDbContext : IdentityUserContext<IdentityUser>
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<UserInfo> UsersInfo { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Rental> Rentals { get; set; }

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
