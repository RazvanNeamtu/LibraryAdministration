using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryAdministration.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b88e0b2b-8fa6-48cb-98ff-8f0a4481d363", 0, "6483980d-65f6-4ef8-a274-a76d6122cdd3", "admin@admin.ro", false, false, null, "ADMIN@ADMIN.RO", "ADMIN", "AQAAAAIAAYagAAAAEChNlSvVTC5j0Lf7KuMN5BsSFExI5TyRbProHh5db+tyV6LJr5pQcLRwYt+KkaQB2Q==", null, false, "PKGPPFXQRYMHBRJQ4TSG4DA5EROZWGGZ", false, "admin" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Mircea", "Eliade" },
                    { 2, "Mihail", "Sadoveanu" },
                    { 3, "Liviu", "Rebreanu" },
                    { 4, "George", "Calinescu" },
                    { 5, "Camil", "Petrescu" },
                    { 6, "Mihai", "Eminescu" },
                    { 7, "Razvan", "Neamtu" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "Path" },
                values: new object[,]
                {
                    { 1, "Baltagul.jpg", "Images/Baltagul.jpg" },
                    { 2, "DumbravaMinunata.jpg", "Images/DumbravaMinunata.jpg" },
                    { 3, "EnigmaOtiliei.jpg", "Images/EnigmaOtiliei.jpg" },
                    { 4, "HanulAncutei.jpg", "Images/HanulAncutei.jpg" },
                    { 5, "Ion.jpg", "Images/Ion.jpg" },
                    { 6, "Luceafarul.jpg", "Images/Luceafarul.jpg" },
                    { 7, "Maitreyi.jpg", "Images/Maitreyi.jpg" },
                    { 8, "PadureaSpanzuratilor.jpg", "Images/PadureaSpanzuratilor.jpg" },
                    { 9, "UltimaNoapteDeDragosteIntaiaNoapteDeRazboi.jpg", "Images/UltimaNoapteDeDragosteIntaiaNoapteDeRazboi.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "ImageId", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 7, 20, "Maitreyi" },
                    { 2, 1, 5, "Baltagul" },
                    { 3, 2, 5, "Dumbrava Minunata" },
                    { 4, 4, 7, "Hanul Ancutei" },
                    { 5, 5, 10, "Ion" },
                    { 6, 8, 1, "Padurea Spanzuratilor" },
                    { 7, 3, 2, "Enigma Otiliei" },
                    { 8, 9, 2, "Ultima noapte de dragoste, intaia noapte de razboi" },
                    { 9, 6, 3, "Luceafarul" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BooksId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 4, 7 },
                    { 5, 8 },
                    { 6, 9 },
                    { 7, 1 },
                    { 7, 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b88e0b2b-8fa6-48cb-98ff-8f0a4481d363");

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BooksId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BooksId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BooksId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BooksId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BooksId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BooksId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BooksId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BooksId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BooksId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorId", "BooksId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
