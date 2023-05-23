using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAdministration.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserInfoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f34cb864-7e22-41ca-9d7d-2e9279c791ec");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4f9b5f27-d67f-4d31-b445-37fab32132af", 0, "6483980d-65f6-4ef8-a274-a76d6122cdd3", "admin@admin.ro", false, false, null, "ADMIN@ADMIN.RO", "ADMIN", "AQAAAAIAAYagAAAAEChNlSvVTC5j0Lf7KuMN5BsSFExI5TyRbProHh5db+tyV6LJr5pQcLRwYt+KkaQB2Q==", null, false, "PKGPPFXQRYMHBRJQ4TSG4DA5EROZWGGZ", false, "admin" });

            migrationBuilder.InsertData(
                table: "UsersInfo",
                columns: new[] { "Id", "CNP", "FirstName", "IdentityUserId", "LastName" },
                values: new object[] { 1, "1234567891234", "Admin", "4f9b5f27-d67f-4d31-b445-37fab32132af", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersInfo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f9b5f27-d67f-4d31-b445-37fab32132af");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f34cb864-7e22-41ca-9d7d-2e9279c791ec", 0, "6483980d-65f6-4ef8-a274-a76d6122cdd3", "admin@admin.ro", false, false, null, "ADMIN@ADMIN.RO", "ADMIN", "AQAAAAIAAYagAAAAEChNlSvVTC5j0Lf7KuMN5BsSFExI5TyRbProHh5db+tyV6LJr5pQcLRwYt+KkaQB2Q==", null, false, "PKGPPFXQRYMHBRJQ4TSG4DA5EROZWGGZ", false, "admin" });
        }
    }
}
