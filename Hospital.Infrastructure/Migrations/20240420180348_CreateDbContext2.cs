using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDbContext2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Auths_Id",
                table: "Roles");

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("5450c5e8-7fd8-48f7-b496-ab95a13f99bb"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("8bd0f732-03ed-4685-86e7-0b022098141a"));

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId1",
                table: "Auths",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("846cc547-7a5d-4979-a59d-28b315ac5acc"), "Абрешим", "Обласной болница" },
                    { new Guid("eb450346-dad9-4f2d-b5fb-c4cf44758655"), "Гулистон", "Гор болница" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auths_RoleId",
                table: "Auths",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auths_RoleId1",
                table: "Auths",
                column: "RoleId1",
                unique: true,
                filter: "[RoleId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Auths_Roles_RoleId",
                table: "Auths",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Auths_Roles_RoleId1",
                table: "Auths",
                column: "RoleId1",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auths_Roles_RoleId",
                table: "Auths");

            migrationBuilder.DropForeignKey(
                name: "FK_Auths_Roles_RoleId1",
                table: "Auths");

            migrationBuilder.DropIndex(
                name: "IX_Auths_RoleId",
                table: "Auths");

            migrationBuilder.DropIndex(
                name: "IX_Auths_RoleId1",
                table: "Auths");

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("846cc547-7a5d-4979-a59d-28b315ac5acc"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("eb450346-dad9-4f2d-b5fb-c4cf44758655"));

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "Auths");

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("5450c5e8-7fd8-48f7-b496-ab95a13f99bb"), "Абрешим", "Обласной болница" },
                    { new Guid("8bd0f732-03ed-4685-86e7-0b022098141a"), "Гулистон", "Гор болница" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Auths_Id",
                table: "Roles",
                column: "Id",
                principalTable: "Auths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
