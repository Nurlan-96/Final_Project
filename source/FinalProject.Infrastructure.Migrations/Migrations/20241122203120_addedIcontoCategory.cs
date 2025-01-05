using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class addedIcontoCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "icon",
                table: "category",
                type: "text",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "icon",
                table: "category");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 19, 59, 55, 891, DateTimeKind.Utc).AddTicks(3363));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 19, 59, 55, 891, DateTimeKind.Utc).AddTicks(3369));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 19, 59, 55, 891, DateTimeKind.Utc).AddTicks(3370));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_date", "password" },
                values: new object[] { new DateTime(2024, 11, 22, 19, 59, 55, 891, DateTimeKind.Utc).AddTicks(3541), "AQAAAAEACSfAAAAAENQStdEBGNVjSBosqk4EOsWAEdHHJbJsY1RNeVKy6zUb7R2AgEHVwJN0uTYaEMoGYg==" });
        }
    }
}
