using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQueueEntryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("c25dc038-3aa7-456c-8bd8-032b065bdf66"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("2b0242d3-8040-4510-8311-782a35ee6179"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("68654943-68a7-4752-ab59-8a9d5728e29c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a4d20872-f19a-4811-b4c5-2c1d5ccb5981"));

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: new Guid("b3c66848-7b97-4d61-90be-e1d263baaef5"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("ab07ffa4-6bf0-4f67-b536-4cdb8ed4b43b"));

            migrationBuilder.CreateTable(
                name: "QueueEntrys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnqueueTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DequeueTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueEntrys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QueueEntrys_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("98b21a89-d5e6-4cf7-b8a8-65b724b31be6"), "Гулистон", "Гор болница" },
                    { new Guid("b41d5dce-0064-4e17-9352-8f39a0137c08"), "Абрешим", "Обласной болница" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b2fd7dad-05b8-4c9a-994b-06967c6ea25e"), "Admin" });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Address", "DateOfBirth", "DateRegister", "FirstName", "LastName", "PhoneNumber", "PositionId" },
                values: new object[] { new Guid("2c0789a7-fe4c-46c1-868c-4e377cfd11f3"), "Panjakent", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shahzodjon", "Jonizoqov", "+992927758499", new Guid("b2fd7dad-05b8-4c9a-994b-06967c6ea25e") });

            migrationBuilder.InsertData(
                table: "Auths",
                columns: new[] { "Id", "IsBlocked", "Login", "Password", "RefreshToken", "WorkerId" },
                values: new object[] { new Guid("81d5ebd9-89ae-4216-ac56-73d7b007ab5b"), false, "SupperAdmin123", "!@#123#@!", "", new Guid("2c0789a7-fe4c-46c1-868c-4e377cfd11f3") });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "WorkerId" },
                values: new object[] { new Guid("5bb97926-a33b-48a7-b829-21232d7aa58c"), "Admin", new Guid("2c0789a7-fe4c-46c1-868c-4e377cfd11f3") });

            migrationBuilder.CreateIndex(
                name: "IX_QueueEntrys_AppointmentId",
                table: "QueueEntrys",
                column: "AppointmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QueueEntrys");

            migrationBuilder.DeleteData(
                table: "Auths",
                keyColumn: "Id",
                keyValue: new Guid("81d5ebd9-89ae-4216-ac56-73d7b007ab5b"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("98b21a89-d5e6-4cf7-b8a8-65b724b31be6"));

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: new Guid("b41d5dce-0064-4e17-9352-8f39a0137c08"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5bb97926-a33b-48a7-b829-21232d7aa58c"));

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: new Guid("2c0789a7-fe4c-46c1-868c-4e377cfd11f3"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b2fd7dad-05b8-4c9a-994b-06967c6ea25e"));

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("2b0242d3-8040-4510-8311-782a35ee6179"), "Гулистон", "Гор болница" },
                    { new Guid("68654943-68a7-4752-ab59-8a9d5728e29c"), "Абрешим", "Обласной болница" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("ab07ffa4-6bf0-4f67-b536-4cdb8ed4b43b"), "Admin" });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Address", "DateOfBirth", "DateRegister", "FirstName", "LastName", "PhoneNumber", "PositionId" },
                values: new object[] { new Guid("b3c66848-7b97-4d61-90be-e1d263baaef5"), "Panjakent", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shahzodjon", "Jonizoqov", "+992927758499", new Guid("ab07ffa4-6bf0-4f67-b536-4cdb8ed4b43b") });

            migrationBuilder.InsertData(
                table: "Auths",
                columns: new[] { "Id", "IsBlocked", "Login", "Password", "RefreshToken", "WorkerId" },
                values: new object[] { new Guid("c25dc038-3aa7-456c-8bd8-032b065bdf66"), false, "SupperAdmin123", "!@#123#@!", "", new Guid("b3c66848-7b97-4d61-90be-e1d263baaef5") });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "WorkerId" },
                values: new object[] { new Guid("a4d20872-f19a-4811-b4c5-2c1d5ccb5981"), "Admin", new Guid("b3c66848-7b97-4d61-90be-e1d263baaef5") });
        }
    }
}
