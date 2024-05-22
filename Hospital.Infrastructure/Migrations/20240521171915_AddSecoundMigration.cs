using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSecoundMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("137b90fd-78d1-4e51-b782-71211a89d6f4"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("3fca271d-4f3b-4809-9980-42582a0e4c6d"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("57f9270b-7183-4c4a-957b-ef4872599501"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1bddbe1b-bc07-4a6b-8ce7-780829183236"));

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: new Guid("ddf1c710-c42b-4900-b985-973d96c4f5b8"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("59acaabf-040a-4da1-a1f8-94f791abeee9"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("411ef03d-ae2d-49d9-b199-109feb3ed48f"), "Абрешим", "Обласной болница" },
                    { new Guid("cc240972-dee2-4bcf-a09a-928bd3e49485"), "Гулистон", "Гор болница" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b65015d7-1718-4370-bb28-e74d3802d6e0"), "Admin" });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Address", "DateOfBirth", "DateRegister", "FirstName", "LastName", "PhoneNumber", "PositionId" },
                values: new object[] { new Guid("4864f4cd-4c2d-4258-ad24-ab363f3e063d"), "Panjakent", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shahzodjon", "Jonizoqov", "+992927758499", new Guid("b65015d7-1718-4370-bb28-e74d3802d6e0") });

            migrationBuilder.InsertData(
                table: "Auths",
                columns: new[] { "Id", "IsBlocked", "Login", "Password", "RefreshToken", "WorkerId" },
                values: new object[] { new Guid("841569fd-0659-4d33-8d66-8fe6cccfcc03"), false, "SupperAdmin123", "!@#123#@!", "", new Guid("4864f4cd-4c2d-4258-ad24-ab363f3e063d") });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "WorkerId" },
                values: new object[] { new Guid("e157f1c7-87ce-4b0e-87da-d2bc9eefea1c"), "Admin", new Guid("4864f4cd-4c2d-4258-ad24-ab363f3e063d") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("841569fd-0659-4d33-8d66-8fe6cccfcc03"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("411ef03d-ae2d-49d9-b199-109feb3ed48f"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("cc240972-dee2-4bcf-a09a-928bd3e49485"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e157f1c7-87ce-4b0e-87da-d2bc9eefea1c"));

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: new Guid("4864f4cd-4c2d-4258-ad24-ab363f3e063d"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b65015d7-1718-4370-bb28-e74d3802d6e0"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "Appointments");

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("3fca271d-4f3b-4809-9980-42582a0e4c6d"), "Абрешим", "Обласной болница" },
                    { new Guid("57f9270b-7183-4c4a-957b-ef4872599501"), "Гулистон", "Гор болница" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("59acaabf-040a-4da1-a1f8-94f791abeee9"), "Admin" });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Address", "DateOfBirth", "DateRegister", "FirstName", "LastName", "PhoneNumber", "PositionId" },
                values: new object[] { new Guid("ddf1c710-c42b-4900-b985-973d96c4f5b8"), "Panjakent", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shahzodjon", "Jonizoqov", "+992927758499", new Guid("59acaabf-040a-4da1-a1f8-94f791abeee9") });

            migrationBuilder.InsertData(
                table: "Auths",
                columns: new[] { "Id", "IsBlocked", "Login", "Password", "RefreshToken", "WorkerId" },
                values: new object[] { new Guid("137b90fd-78d1-4e51-b782-71211a89d6f4"), false, "SupperAdmin123", "!@#123#@!", "", new Guid("ddf1c710-c42b-4900-b985-973d96c4f5b8") });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "WorkerId" },
                values: new object[] { new Guid("1bddbe1b-bc07-4a6b-8ce7-780829183236"), "Admin", new Guid("ddf1c710-c42b-4900-b985-973d96c4f5b8") });
        }
    }
}
