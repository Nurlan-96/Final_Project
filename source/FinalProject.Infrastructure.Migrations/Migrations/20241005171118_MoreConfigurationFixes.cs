using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class MoreConfigurationFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "user",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "IsBanned",
                table: "user",
                newName: "is_banned");

            migrationBuilder.RenameColumn(
                name: "companyname",
                table: "cvjob",
                newName: "company_name");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "cvjob",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "cvjob",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "phonenumber",
                table: "cventity",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "cventity",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "cventity",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "EmploymentType",
                table: "cventity",
                newName: "employment_type");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "cventity",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "category",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "category",
                newName: "created_date");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 17, 11, 18, 299, DateTimeKind.Utc).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 17, 11, 18, 299, DateTimeKind.Utc).AddTicks(9303));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 17, 11, 18, 299, DateTimeKind.Utc).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_date", "password" },
                values: new object[] { new DateTime(2024, 10, 5, 17, 11, 18, 299, DateTimeKind.Utc).AddTicks(9454), "AQAAAAEACSfAAAAAEK8zAXF5GxYQdDNCUC0PWD7co8JCaa4svPzey5do14+4bDHKLXKwavndwnn6Jc4Bzg==" });

            migrationBuilder.CreateIndex(
                name: "IX_user_phone_number",
                table: "user",
                column: "phone_number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_phone_number",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "user",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "is_banned",
                table: "user",
                newName: "IsBanned");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "cvjob",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "cvjob",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "company_name",
                table: "cvjob",
                newName: "companyname");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "cventity",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "cventity",
                newName: "phonenumber");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "cventity",
                newName: "fullname");

            migrationBuilder.RenameColumn(
                name: "employment_type",
                table: "cventity",
                newName: "EmploymentType");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "cventity",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "category",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "category",
                newName: "CreatedDate");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 17, 5, 59, 858, DateTimeKind.Utc).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 17, 5, 59, 858, DateTimeKind.Utc).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 17, 5, 59, 858, DateTimeKind.Utc).AddTicks(5807));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_date", "password" },
                values: new object[] { new DateTime(2024, 10, 5, 17, 5, 59, 858, DateTimeKind.Utc).AddTicks(5968), "AQAAAAEACSfAAAAAEAtZHtsrCoEf4QLkeWbC2cP8pmB8kOuRGUeF32PW/AzfiWauzqd58dcVQFAmFmWNDA==" });
        }
    }
}
