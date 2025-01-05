using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class changedRequierementsPropInJobs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 24, 18, 22, 41, 159, DateTimeKind.Utc).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 24, 18, 22, 41, 159, DateTimeKind.Utc).AddTicks(8763));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 24, 18, 22, 41, 159, DateTimeKind.Utc).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_date", "password" },
                values: new object[] { new DateTime(2024, 10, 24, 18, 22, 41, 159, DateTimeKind.Utc).AddTicks(8938), "AQAAAAEACSfAAAAAEDbXTZHfMwf+8dWNcp63B2tr8cYIdFOZQmdTt2OouJ5/CP5FV/Eoza1lbiZPkGh11Q==" });
        }
    }
}
