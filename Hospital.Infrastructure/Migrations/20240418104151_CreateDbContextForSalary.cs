using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDbContextForSalary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("2012c297-e02b-4983-b5fb-d52802db1946"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("ae0c39b4-ae27-47cf-ad3b-f1afe61d3e5a"));

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "SelaryId",
                table: "Workers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AuthId",
                table: "Workers",
                newName: "SalaryId");

            migrationBuilder.CreateTable(
                name: "Salarys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Bonus = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salarys", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("27f1362a-2d95-4946-a428-bfe6a855d8da"), "Абрешим", "Обласной болница" },
                    { new Guid("fb38d341-fee1-4df9-9410-ca1d3163f7bc"), "Гулистон", "Гор болница" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_SalaryId",
                table: "Workers",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_UserId",
                table: "Workers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Salarys_SalaryId",
                table: "Workers",
                column: "SalaryId",
                principalTable: "Salarys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Users_UserId",
                table: "Workers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Salarys_SalaryId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Users_UserId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "Salarys");

            migrationBuilder.DropIndex(
                name: "IX_Workers_SalaryId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_UserId",
                table: "Workers");

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("27f1362a-2d95-4946-a428-bfe6a855d8da"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("fb38d341-fee1-4df9-9410-ca1d3163f7bc"));

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Workers",
                newName: "SelaryId");

            migrationBuilder.RenameColumn(
                name: "SalaryId",
                table: "Workers",
                newName: "AuthId");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkerId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("2012c297-e02b-4983-b5fb-d52802db1946"), "Абрешим", "Обласной болница" },
                    { new Guid("ae0c39b4-ae27-47cf-ad3b-f1afe61d3e5a"), "Гулистон", "Гор болница" }
                });
        }
    }
}
