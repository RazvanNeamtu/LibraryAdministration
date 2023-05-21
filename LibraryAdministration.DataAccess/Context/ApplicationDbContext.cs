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
            modelBuilder.SeedData();
        }
    }

    public static class SeedDataHelper
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            
            #region users
            var adminUser = new IdentityUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.ro",
                NormalizedEmail = "ADMIN@ADMIN.RO",
                PasswordHash = "AQAAAAIAAYagAAAAEChNlSvVTC5j0Lf7KuMN5BsSFExI5TyRbProHh5db+tyV6LJr5pQcLRwYt+KkaQB2Q==",
                SecurityStamp = "PKGPPFXQRYMHBRJQ4TSG4DA5EROZWGGZ",
                ConcurrencyStamp = "6483980d-65f6-4ef8-a274-a76d6122cdd3"
            };
            #endregion

            #region images
            var image1 = new Image { Id = 1, Name = "1Baltagul.jpg", OriginalName = "1.jpg", Path = "..\\..\\..\\..\\Images\\Baltagul.jpg" };
            var image2 = new Image { Id = 2, Name = "2DumbravaMinunata.jpg", OriginalName = "2.jpg", Path = "..\\..\\..\\..\\Images\\DumbravaMinunata.jpg" };
            var image3 = new Image { Id = 3, Name = "3EnigmaOtiliei.jpg", OriginalName = "3.jpg", Path = "..\\..\\..\\..\\Images\\EnigmaOtiliei.jpg" };
            var image4 = new Image { Id = 4, Name = "4HanulAncutei.jpg", OriginalName = "4.jpg", Path = "..\\..\\..\\..\\Images\\HanulAncutei.jpg" };
            var image5 = new Image { Id = 5, Name = "5Ion.jpg", OriginalName = "5.jpg", Path = "..\\..\\..\\..\\Images\\on.jpg" };
            var image6 = new Image { Id = 6, Name = "6Luceafarul.jpg", OriginalName = "6.jpg", Path = "..\\..\\..\\..\\Images\\Luceafarul.jpg" };
            var image7 = new Image { Id = 7, Name = "7Maitreyi.jpg", OriginalName = "7.jpg", Path = "..\\..\\..\\..\\Images\\Maitreyi.jpg" };
            var image8 = new Image { Id = 8, Name = "8PadureaSpanzuratilor.jpg", OriginalName = "8.jpg", Path = "..\\..\\..\\..\\Images\\PadureaSpanzuratilor.jpg" };
            var image9 = new Image { Id = 9, Name = "9UltimaNoapteDeDragosteIntaiaNoapteDeRazboi.jpg", OriginalName = "9.jpg", Path = "..\\..\\..\\..\\Images\\UltimaNoapteDeDragosteIntaiaNoapteDeRazboi.jpg" };

            var imageList = new List<Image>() { image1, image2, image3, image4, image5, image6, image7, image8, image9 };
            #endregion

            #region books
            var book1 = new Book { Id = 1, Title = "Maitreyi", Quantity = 20, ImageId = 7 };
            var book2 = new Book { Id = 2, Title = "Baltagul", Quantity = 5, ImageId = 1 };
            var book3 = new Book { Id = 3, Title = "Dumbrava Minunata", Quantity = 5, ImageId = 2 };
            var book4 = new Book { Id = 4, Title = "Hanul Ancutei", Quantity = 7, ImageId = 4 };
            var book5 = new Book { Id = 5, Title = "Ion", Quantity = 10, ImageId = 5 };
            var book6 = new Book { Id = 6, Title = "Padurea Spanzuratilor", Quantity = 1, ImageId = 8 };
            var book7 = new Book { Id = 7, Title = "Enigma Otiliei", Quantity = 2, ImageId = 3 };
            var book8 = new Book { Id = 8, Title = "Ultima noapte de dragoste, intaia noapte de razboi", Quantity = 2, ImageId = 9 };
            var book9 = new Book { Id = 9, Title = "Luceafarul", Quantity = 3, ImageId = 6 };

            var bookList = new List<Book>() { book1, book2, book3, book4, book5, book6, book7, book8, book9 };
            #endregion

            #region authors
            var author1 = new Author { Id = 1, FirstName = "Mircea", LastName = "Eliade" };
            var author2 = new Author { Id = 2, FirstName = "Mihail", LastName = "Sadoveanu" };
            var author3 = new Author { Id = 3, FirstName = "Liviu", LastName = "Rebreanu" };
            var author4 = new Author { Id = 4, FirstName = "George", LastName = "Calinescu" };
            var author5 = new Author { Id = 5, FirstName = "Camil", LastName = "Petrescu" };
            var author6 = new Author { Id = 6, FirstName = "Mihai", LastName = "Eminescu" };
            var author7 = new Author { Id = 7, FirstName = "Razvan", LastName = "Neamtu" };

            var authorList = new List<Author>() { author1, author2, author3, author4, author5, author6, author7 };
            #endregion

            #region authorBook
            var authorBooks = new List<object> {
                new { AuthorId = author1.Id, BooksId = book1.Id },
                new { AuthorId = author2.Id, BooksId = book2.Id },
                new { AuthorId = author2.Id, BooksId = book3.Id },
                new { AuthorId = author3.Id, BooksId = book4.Id },
                new { AuthorId = author3.Id, BooksId = book5.Id },
                new { AuthorId = author4.Id, BooksId = book7.Id },
                new { AuthorId = author5.Id, BooksId = book8.Id },
                new { AuthorId = author6.Id, BooksId = book9.Id },
                new { AuthorId = author7.Id, BooksId = book9.Id },
                new { AuthorId = author7.Id, BooksId = book1.Id },
            };
            #endregion
            modelBuilder.Entity<IdentityUser>().HasData(adminUser);
            modelBuilder.Entity<Image>().HasData(imageList);
            modelBuilder.Entity<Book>().HasData(bookList);
            modelBuilder.Entity<Author>().HasData(authorList);
            modelBuilder.Entity<Book>().HasMany(p => p.Authors).WithMany(m => m.Books).UsingEntity(j => j.HasData(authorBooks));
            modelBuilder.Entity<Book>().HasMany(p => p.Authors).WithMany(m => m.Books)
                .UsingEntity("AuthorBook",
                            l => l.HasOne(typeof(Author)).WithMany().HasForeignKey("AuthorId").HasPrincipalKey(nameof(Author.Id)),
                             r => r.HasOne(typeof(Book)).WithMany().HasForeignKey("BooksId").HasPrincipalKey(nameof(Book.Id)),
                             j => j.HasKey("AuthorId", "BooksId"));
        }
    }
}
