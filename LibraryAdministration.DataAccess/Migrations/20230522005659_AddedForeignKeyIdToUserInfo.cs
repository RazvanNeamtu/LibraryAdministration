using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAdministration.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKeyIdToUserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c3d9b3b2-9321-460d-97aa-3bcd74e6ca23");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f34cb864-7e22-41ca-9d7d-2e9279c791ec", 0, "6483980d-65f6-4ef8-a274-a76d6122cdd3", "admin@admin.ro", false, false, null, "ADMIN@ADMIN.RO", "ADMIN", "AQAAAAIAAYagAAAAEChNlSvVTC5j0Lf7KuMN5BsSFExI5TyRbProHh5db+tyV6LJr5pQcLRwYt+KkaQB2Q==", null, false, "PKGPPFXQRYMHBRJQ4TSG4DA5EROZWGGZ", false, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f34cb864-7e22-41ca-9d7d-2e9279c791ec");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c3d9b3b2-9321-460d-97aa-3bcd74e6ca23", 0, "6483980d-65f6-4ef8-a274-a76d6122cdd3", "admin@admin.ro", false, false, null, "ADMIN@ADMIN.RO", "ADMIN", "AQAAAAIAAYagAAAAEChNlSvVTC5j0Lf7KuMN5BsSFExI5TyRbProHh5db+tyV6LJr5pQcLRwYt+KkaQB2Q==", null, false, "PKGPPFXQRYMHBRJQ4TSG4DA5EROZWGGZ", false, "admin" });
        }
    }
}
