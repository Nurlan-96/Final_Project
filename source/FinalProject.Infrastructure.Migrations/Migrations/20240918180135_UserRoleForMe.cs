using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleForMe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 18, 18, 1, 34, 894, DateTimeKind.Utc).AddTicks(2169));

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "CreatedDate", "name", "UpdatedDate" },
                values: new object[] { 2, new DateTime(2024, 9, 18, 18, 1, 34, 894, DateTimeKind.Utc).AddTicks(2176), "User", null });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "password" },
                values: new object[] { new DateTime(2024, 9, 18, 18, 1, 34, 894, DateTimeKind.Utc).AddTicks(2306), "AQAAAAEACSfAAAAAEAbDnBwcKjrXAapsKUikU4iCrH3QsTXvz/i+7fF8lc1qCU3RwR072bolC6xXOx76+A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 17, 18, 32, 12, 56, DateTimeKind.Utc).AddTicks(7473));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "password" },
                values: new object[] { new DateTime(2024, 9, 17, 18, 32, 12, 56, DateTimeKind.Utc).AddTicks(7600), "AQAAAAEACSfAAAAAEIAbX+WhcU5OWbruyXSeloNPUpsdszmxRzid70p9Q+2lM9VKkwtBQK+FkE9sm5eKYQ==" });
        }
    }
}
