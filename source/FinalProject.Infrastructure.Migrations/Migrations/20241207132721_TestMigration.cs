using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class TestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 7, 13, 27, 21, 237, DateTimeKind.Utc).AddTicks(7275));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 7, 13, 27, 21, 237, DateTimeKind.Utc).AddTicks(7279));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 7, 13, 27, 21, 237, DateTimeKind.Utc).AddTicks(7280));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_date", "password" },
                values: new object[] { new DateTime(2024, 12, 7, 13, 27, 21, 237, DateTimeKind.Utc).AddTicks(7408), "AQAAAAEACSfAAAAAEFhqH4SEE80nb4FFvxqN5ZPdfmkjpYJjYMiyu2QbKNwgxZgiPWw53hdotbYAngv0Vg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 20, 31, 20, 246, DateTimeKind.Utc).AddTicks(9440));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 20, 31, 20, 246, DateTimeKind.Utc).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 20, 31, 20, 246, DateTimeKind.Utc).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_date", "password" },
                values: new object[] { new DateTime(2024, 11, 22, 20, 31, 20, 246, DateTimeKind.Utc).AddTicks(9592), "AQAAAAEACSfAAAAAEFy3+hNxlonQ1h/mmLQfws0ITjW1LvLP5JK7/WNynckGly2iEssEnNBeIC3v0DHsTw==" });
        }
    }
}
