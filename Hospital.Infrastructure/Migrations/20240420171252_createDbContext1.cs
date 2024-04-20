using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createDbContext1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("402f4b92-4842-482f-899b-0cf995cc9551"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("a3da216e-e37c-431e-b927-ed9645ce9ce1"));

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("5450c5e8-7fd8-48f7-b496-ab95a13f99bb"), "Абрешим", "Обласной болница" },
                    { new Guid("8bd0f732-03ed-4685-86e7-0b022098141a"), "Гулистон", "Гор болница" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("5450c5e8-7fd8-48f7-b496-ab95a13f99bb"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("8bd0f732-03ed-4685-86e7-0b022098141a"));

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("402f4b92-4842-482f-899b-0cf995cc9551"), "Абрешим", "Обласной болница" },
                    { new Guid("a3da216e-e37c-431e-b927-ed9645ce9ce1"), "Гулистон", "Гор болница" }
                });
        }
    }
}
