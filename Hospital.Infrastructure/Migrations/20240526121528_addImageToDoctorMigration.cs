using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addImageToDoctorMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Doctors",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Information",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("5ef154d6-dab6-4c95-b501-05e88adc827e"), "Абрешим", "Обласной болница" },
                    { new Guid("860bde53-3f9f-4cdc-8741-eeea75ef5b3a"), "Гулистон", "Гор болница" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b669a6d1-278c-42c0-a22d-bf030cc9caf0"), "Admin" });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Address", "DateOfBirth", "DateRegister", "FirstName", "LastName", "PhoneNumber", "PositionId" },
                values: new object[] { new Guid("d59c06ab-11d8-41d3-90e9-56e18b3204f5"), "Panjakent", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shahzodjon", "Jonizoqov", "+992927758499", new Guid("b669a6d1-278c-42c0-a22d-bf030cc9caf0") });

            migrationBuilder.InsertData(
                table: "Auths",
                columns: new[] { "Id", "IsBlocked", "Login", "Password", "RefreshToken", "WorkerId" },
                values: new object[] { new Guid("91384768-2568-4327-b1f5-1e7edf4a51c4"), false, "SupperAdmin123", "!@#123#@!", "", new Guid("d59c06ab-11d8-41d3-90e9-56e18b3204f5") });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "WorkerId" },
                values: new object[] { new Guid("baca0d9f-835b-4267-a17b-445440256a03"), "Admin", new Guid("d59c06ab-11d8-41d3-90e9-56e18b3204f5") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("91384768-2568-4327-b1f5-1e7edf4a51c4"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("5ef154d6-dab6-4c95-b501-05e88adc827e"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("860bde53-3f9f-4cdc-8741-eeea75ef5b3a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("baca0d9f-835b-4267-a17b-445440256a03"));

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: new Guid("d59c06ab-11d8-41d3-90e9-56e18b3204f5"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b669a6d1-278c-42c0-a22d-bf030cc9caf0"));

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Information",
                table: "Doctors");

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
    }
}
