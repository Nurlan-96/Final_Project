using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class RoleSeedAndIgnore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "role");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 18, 18, 7, 59, 772, DateTimeKind.Utc).AddTicks(4515));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 18, 18, 7, 59, 772, DateTimeKind.Utc).AddTicks(4521));

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "CreatedDate", "name" },
                values: new object[] { 3, new DateTime(2024, 9, 18, 18, 7, 59, 772, DateTimeKind.Utc).AddTicks(4523), "Agent" });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "password", "PhoneNumber" },
                values: new object[] { new DateTime(2024, 9, 18, 18, 7, 59, 772, DateTimeKind.Utc).AddTicks(4644), "AQAAAAEACSfAAAAAEPCMhbR4glwdPKAK6aYvrWyUQsz2Z4CGg5wm3NBBPeboapClLT0v1+2jN2U5X0XDrA==", "000000" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "role",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 9, 18, 18, 1, 34, 894, DateTimeKind.Utc).AddTicks(2169), null });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 9, 18, 18, 1, 34, 894, DateTimeKind.Utc).AddTicks(2176), null });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "password", "PhoneNumber" },
                values: new object[] { new DateTime(2024, 9, 18, 18, 1, 34, 894, DateTimeKind.Utc).AddTicks(2306), "AQAAAAEACSfAAAAAEAbDnBwcKjrXAapsKUikU4iCrH3QsTXvz/i+7fF8lc1qCU3RwR072bolC6xXOx76+A==", "Test" });
        }
    }
}
