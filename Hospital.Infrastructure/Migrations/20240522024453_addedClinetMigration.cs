using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedClinetMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("3cff9e1f-717a-42be-a061-c13dbfa6d2cf"), "Гулистон", "Гор болница" },
                    { new Guid("b3740b9b-38dd-417e-9fd0-01ddcc10a6ce"), "Абрешим", "Обласной болница" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b2bd64c3-e072-4982-b399-a272ce786635"), "Admin" });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Address", "DateOfBirth", "DateRegister", "FirstName", "LastName", "PhoneNumber", "PositionId" },
                values: new object[] { new Guid("6f253175-a69f-4b28-ac5a-597d40803c51"), "Panjakent", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shahzodjon", "Jonizoqov", "+992927758499", new Guid("b2bd64c3-e072-4982-b399-a272ce786635") });

            migrationBuilder.InsertData(
                table: "Auths",
                columns: new[] { "Id", "IsBlocked", "Login", "Password", "RefreshToken", "WorkerId" },
                values: new object[] { new Guid("5bd12d15-4a1c-4f4a-af0e-42ba914dc5b3"), false, "SupperAdmin123", "!@#123#@!", "", new Guid("6f253175-a69f-4b28-ac5a-597d40803c51") });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "WorkerId" },
                values: new object[] { new Guid("f8b70e5a-bca6-493d-8e6d-d595cb844dd6"), "Admin", new Guid("6f253175-a69f-4b28-ac5a-597d40803c51") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DeleteData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("5bd12d15-4a1c-4f4a-af0e-42ba914dc5b3"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("3cff9e1f-717a-42be-a061-c13dbfa6d2cf"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("b3740b9b-38dd-417e-9fd0-01ddcc10a6ce"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f8b70e5a-bca6-493d-8e6d-d595cb844dd6"));

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: new Guid("6f253175-a69f-4b28-ac5a-597d40803c51"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b2bd64c3-e072-4982-b399-a272ce786635"));

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
    }
}
