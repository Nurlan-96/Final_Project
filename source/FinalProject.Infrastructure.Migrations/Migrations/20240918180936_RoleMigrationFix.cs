using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class RoleMigrationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 18, 18, 9, 36, 337, DateTimeKind.Utc).AddTicks(4697));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 18, 18, 9, 36, 337, DateTimeKind.Utc).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "name" },
                values: new object[] { new DateTime(2024, 9, 18, 18, 9, 36, 337, DateTimeKind.Utc).AddTicks(4703), "Company" });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "password" },
                values: new object[] { new DateTime(2024, 9, 18, 18, 9, 36, 337, DateTimeKind.Utc).AddTicks(4811), "AQAAAAEACSfAAAAAEAiD/UeaR0n/Jr9DqcEnNnEjvjr42JcjnIDHTQpRJyZ4muAxj4gV63FgP2/o+q+mSg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "name" },
                values: new object[] { new DateTime(2024, 9, 18, 18, 7, 59, 772, DateTimeKind.Utc).AddTicks(4523), "Agent" });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "password" },
                values: new object[] { new DateTime(2024, 9, 18, 18, 7, 59, 772, DateTimeKind.Utc).AddTicks(4644), "AQAAAAEACSfAAAAAEPCMhbR4glwdPKAK6aYvrWyUQsz2Z4CGg5wm3NBBPeboapClLT0v1+2jN2U5X0XDrA==" });
        }
    }
}
