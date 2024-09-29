using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class addedOTPtoUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "refresh_token",
                table: "user",
                newName: "refreshtoken");

            migrationBuilder.AddColumn<bool>(
                name: "allowchangewithotp",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "otpcode",
                table: "user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "otpexpireationdate",
                table: "user",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 29, 11, 55, 15, 640, DateTimeKind.Utc).AddTicks(871));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 29, 11, 55, 15, 640, DateTimeKind.Utc).AddTicks(876));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 29, 11, 55, 15, 640, DateTimeKind.Utc).AddTicks(877));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "allowchangewithotp", "CreatedDate", "otpcode", "otpexpireationdate", "password" },
                values: new object[] { false, new DateTime(2024, 9, 29, 11, 55, 15, 640, DateTimeKind.Utc).AddTicks(1014), null, null, "AQAAAAEACSfAAAAAEECtOLdKVQi630IGitQVXHUW0DOBSDnehbkJ3KRqN1NrzExVEk4DGPJAG/AWW5j7Zg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "allowchangewithotp",
                table: "user");

            migrationBuilder.DropColumn(
                name: "otpcode",
                table: "user");

            migrationBuilder.DropColumn(
                name: "otpexpireationdate",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "refreshtoken",
                table: "user",
                newName: "refresh_token");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 27, 17, 17, 58, 791, DateTimeKind.Utc).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 27, 17, 17, 58, 791, DateTimeKind.Utc).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 27, 17, 17, 58, 791, DateTimeKind.Utc).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "password" },
                values: new object[] { new DateTime(2024, 9, 27, 17, 17, 58, 791, DateTimeKind.Utc).AddTicks(7172), "AQAAAAEACSfAAAAAEB/rfnR9+A3+2aAqGJnAW2oC2xkYzgp0HY3J04YjdBXcSnmfH2dv8i0D9MW8AjXJMw==" });
        }
    }
}
