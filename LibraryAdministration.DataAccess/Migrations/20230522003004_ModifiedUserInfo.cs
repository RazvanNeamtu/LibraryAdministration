using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAdministration.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedUserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fbd78994-09eb-46bb-8b79-7630db011c00");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "UsersInfo",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c3d9b3b2-9321-460d-97aa-3bcd74e6ca23", 0, "6483980d-65f6-4ef8-a274-a76d6122cdd3", "admin@admin.ro", false, false, null, "ADMIN@ADMIN.RO", "ADMIN", "AQAAAAIAAYagAAAAEChNlSvVTC5j0Lf7KuMN5BsSFExI5TyRbProHh5db+tyV6LJr5pQcLRwYt+KkaQB2Q==", null, false, "PKGPPFXQRYMHBRJQ4TSG4DA5EROZWGGZ", false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_IdentityUserId",
                table: "UsersInfo",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInfo_AspNetUsers_IdentityUserId",
                table: "UsersInfo",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInfo_AspNetUsers_IdentityUserId",
                table: "UsersInfo");

            migrationBuilder.DropIndex(
                name: "IX_UsersInfo_IdentityUserId",
                table: "UsersInfo");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c3d9b3b2-9321-460d-97aa-3bcd74e6ca23");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "UsersInfo");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fbd78994-09eb-46bb-8b79-7630db011c00", 0, "6483980d-65f6-4ef8-a274-a76d6122cdd3", "admin@admin.ro", false, false, null, "ADMIN@ADMIN.RO", "ADMIN", "AQAAAAIAAYagAAAAEChNlSvVTC5j0Lf7KuMN5BsSFExI5TyRbProHh5db+tyV6LJr5pQcLRwYt+KkaQB2Q==", null, false, "PKGPPFXQRYMHBRJQ4TSG4DA5EROZWGGZ", false, "admin" });
        }
    }
}
