using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDbContext3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("846cc547-7a5d-4979-a59d-28b315ac5acc"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("eb450346-dad9-4f2d-b5fb-c4cf44758655"));

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("43f83862-664f-478d-998d-b36be76e5655"), "Абрешим", "Обласной болница" },
                    { new Guid("d460c5ee-14c2-4515-a867-734737cb6829"), "Гулистон", "Гор болница" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("43f83862-664f-478d-998d-b36be76e5655"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("d460c5ee-14c2-4515-a867-734737cb6829"));

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("846cc547-7a5d-4979-a59d-28b315ac5acc"), "Абрешим", "Обласной болница" },
                    { new Guid("eb450346-dad9-4f2d-b5fb-c4cf44758655"), "Гулистон", "Гор болница" }
                });
        }
    }
}
