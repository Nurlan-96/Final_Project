using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class changedJobPostId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 16, 53, 48, 443, DateTimeKind.Utc).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 16, 53, 48, 443, DateTimeKind.Utc).AddTicks(7687));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 16, 53, 48, 443, DateTimeKind.Utc).AddTicks(7689));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_date", "password" },
                values: new object[] { new DateTime(2024, 11, 22, 16, 53, 48, 443, DateTimeKind.Utc).AddTicks(7842), "AQAAAAEACSfAAAAAEPmJwhgMF7hNjsZpU5dpMFE6KZIYwTUbtvnSWwGV+ybM/xf6tDiQeLPaxM4LflWVcg==" });
        }
    }
}
