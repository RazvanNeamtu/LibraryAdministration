using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAdministration.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedImageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b774ec1-3386-4f1b-94de-d8fb63b85b32");

            migrationBuilder.AddColumn<string>(
                name: "OriginalName",
                table: "Images",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fbd78994-09eb-46bb-8b79-7630db011c00", 0, "6483980d-65f6-4ef8-a274-a76d6122cdd3", "admin@admin.ro", false, false, null, "ADMIN@ADMIN.RO", "ADMIN", "AQAAAAIAAYagAAAAEChNlSvVTC5j0Lf7KuMN5BsSFExI5TyRbProHh5db+tyV6LJr5pQcLRwYt+KkaQB2Q==", null, false, "PKGPPFXQRYMHBRJQ4TSG4DA5EROZWGGZ", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "OriginalName", "Path" },
                values: new object[] { "1Baltagul.jpg", "1.jpg", "..\\..\\..\\..\\Images\\Baltagul.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "OriginalName", "Path" },
                values: new object[] { "2DumbravaMinunata.jpg", "2.jpg", "..\\..\\..\\..\\Images\\DumbravaMinunata.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "OriginalName", "Path" },
                values: new object[] { "3EnigmaOtiliei.jpg", "3.jpg", "..\\..\\..\\..\\Images\\EnigmaOtiliei.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "OriginalName", "Path" },
                values: new object[] { "4HanulAncutei.jpg", "4.jpg", "..\\..\\..\\..\\Images\\HanulAncutei.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "OriginalName", "Path" },
                values: new object[] { "5Ion.jpg", "5.jpg", "..\\..\\..\\..\\Images\\on.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "OriginalName", "Path" },
                values: new object[] { "6Luceafarul.jpg", "6.jpg", "..\\..\\..\\..\\Images\\Luceafarul.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "OriginalName", "Path" },
                values: new object[] { "7Maitreyi.jpg", "7.jpg", "..\\..\\..\\..\\Images\\Maitreyi.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "OriginalName", "Path" },
                values: new object[] { "8PadureaSpanzuratilor.jpg", "8.jpg", "..\\..\\..\\..\\Images\\PadureaSpanzuratilor.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "OriginalName", "Path" },
                values: new object[] { "9UltimaNoapteDeDragosteIntaiaNoapteDeRazboi.jpg", "9.jpg", "..\\..\\..\\..\\Images\\UltimaNoapteDeDragosteIntaiaNoapteDeRazboi.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fbd78994-09eb-46bb-8b79-7630db011c00");

            migrationBuilder.DropColumn(
                name: "OriginalName",
                table: "Images");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7b774ec1-3386-4f1b-94de-d8fb63b85b32", 0, "6483980d-65f6-4ef8-a274-a76d6122cdd3", "admin@admin.ro", false, false, null, "ADMIN@ADMIN.RO", "ADMIN", "AQAAAAIAAYagAAAAEChNlSvVTC5j0Lf7KuMN5BsSFExI5TyRbProHh5db+tyV6LJr5pQcLRwYt+KkaQB2Q==", null, false, "PKGPPFXQRYMHBRJQ4TSG4DA5EROZWGGZ", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Path" },
                values: new object[] { "Baltagul.jpg", "Images/Baltagul.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Path" },
                values: new object[] { "DumbravaMinunata.jpg", "Images/DumbravaMinunata.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Path" },
                values: new object[] { "EnigmaOtiliei.jpg", "Images/EnigmaOtiliei.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Path" },
                values: new object[] { "HanulAncutei.jpg", "Images/HanulAncutei.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Path" },
                values: new object[] { "Ion.jpg", "Images/Ion.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "Path" },
                values: new object[] { "Luceafarul.jpg", "Images/Luceafarul.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "Path" },
                values: new object[] { "Maitreyi.jpg", "Images/Maitreyi.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "Path" },
                values: new object[] { "PadureaSpanzuratilor.jpg", "Images/PadureaSpanzuratilor.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "Path" },
                values: new object[] { "UltimaNoapteDeDragosteIntaiaNoapteDeRazboi.jpg", "Images/UltimaNoapteDeDragosteIntaiaNoapteDeRazboi.jpg" });
        }
    }
}
