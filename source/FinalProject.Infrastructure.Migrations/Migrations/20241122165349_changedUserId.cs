using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class changedUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 21, 12, 7, 56, 391, DateTimeKind.Utc).AddTicks(9386));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 21, 12, 7, 56, 391, DateTimeKind.Utc).AddTicks(9392));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 21, 12, 7, 56, 391, DateTimeKind.Utc).AddTicks(9393));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_date", "password" },
                values: new object[] { new DateTime(2024, 11, 21, 12, 7, 56, 391, DateTimeKind.Utc).AddTicks(9535), "AQAAAAEACSfAAAAAEHTGfhki6aekzjlYhX6UHH03sdgttBFPKZpwtdUf+c1divKxlKacl2RCCPcN+GSHgA==" });
        }
    }
}
