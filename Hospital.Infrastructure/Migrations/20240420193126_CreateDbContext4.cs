using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDbContext4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Salarys_SalaryId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_SalaryId",
                table: "Workers");

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("43f83862-664f-478d-998d-b36be76e5655"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("d460c5ee-14c2-4515-a867-734737cb6829"));

            migrationBuilder.DropColumn(
                name: "AuthId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "SalaryId",
                table: "Workers");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkerId",
                table: "Salarys",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "WorkerId1",
                table: "Auths",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("59bf531f-96c8-4fbf-a53e-7a110e179824"), "Абрешим", "Обласной болница" },
                    { new Guid("ba6cbc6f-fa17-4089-a637-701cbfdc4f44"), "Гулистон", "Гор болница" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salarys_WorkerId",
                table: "Salarys",
                column: "WorkerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auths_WorkerId1",
                table: "Auths",
                column: "WorkerId1",
                unique: true,
                filter: "[WorkerId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Auths_Workers_WorkerId1",
                table: "Auths",
                column: "WorkerId1",
                principalTable: "Workers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salarys_Workers_WorkerId",
                table: "Salarys",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auths_Workers_WorkerId1",
                table: "Auths");

            migrationBuilder.DropForeignKey(
                name: "FK_Salarys_Workers_WorkerId",
                table: "Salarys");

            migrationBuilder.DropIndex(
                name: "IX_Salarys_WorkerId",
                table: "Salarys");

            migrationBuilder.DropIndex(
                name: "IX_Auths_WorkerId1",
                table: "Auths");

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("59bf531f-96c8-4fbf-a53e-7a110e179824"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("ba6cbc6f-fa17-4089-a637-701cbfdc4f44"));

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Salarys");

            migrationBuilder.DropColumn(
                name: "WorkerId1",
                table: "Auths");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthId",
                table: "Workers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SalaryId",
                table: "Workers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("43f83862-664f-478d-998d-b36be76e5655"), "Абрешим", "Обласной болница" },
                    { new Guid("d460c5ee-14c2-4515-a867-734737cb6829"), "Гулистон", "Гор болница" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_SalaryId",
                table: "Workers",
                column: "SalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Salarys_SalaryId",
                table: "Workers",
                column: "SalaryId",
                principalTable: "Salarys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
