using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class addedIsDeletedtoCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Companies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 20, 16, 54, 6, 29, DateTimeKind.Utc).AddTicks(8720));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 20, 16, 54, 6, 29, DateTimeKind.Utc).AddTicks(8731));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 20, 16, 54, 6, 29, DateTimeKind.Utc).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "password" },
                values: new object[] { new DateTime(2024, 9, 20, 16, 54, 6, 29, DateTimeKind.Utc).AddTicks(8857), "AQAAAAEACSfAAAAAEIMhGWKCabZvqbGnFJD7I09fzKdEq0/11LsdbQqxCVXoIG1rC55GFgk7rKwCau5gYQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_jobpost_city_id",
                table: "jobpost",
                column: "city_id");

            migrationBuilder.AddForeignKey(
                name: "FK_jobpost_city_city_id",
                table: "jobpost",
                column: "city_id",
                principalTable: "city",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobpost_city_city_id",
                table: "jobpost");

            migrationBuilder.DropIndex(
                name: "IX_jobpost_city_id",
                table: "jobpost");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Companies");

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
                column: "CreatedDate",
                value: new DateTime(2024, 9, 18, 18, 9, 36, 337, DateTimeKind.Utc).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "password" },
                values: new object[] { new DateTime(2024, 9, 18, 18, 9, 36, 337, DateTimeKind.Utc).AddTicks(4811), "AQAAAAEACSfAAAAAEAiD/UeaR0n/Jr9DqcEnNnEjvjr42JcjnIDHTQpRJyZ4muAxj4gV63FgP2/o+q+mSg==" });
        }
    }
}
