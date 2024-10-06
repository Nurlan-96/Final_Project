using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class FixingConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_cvjob_CVJobId",
                table: "user");

            migrationBuilder.DropForeignKey(
                name: "FK_user_role_role",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "user",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "otpcode",
                table: "user",
                newName: "otp_code");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "user",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "user",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "CVJobId",
                table: "user",
                newName: "cv_job_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_role",
                table: "user",
                newName: "IX_user_role_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_CVJobId",
                table: "user",
                newName: "IX_user_cv_job_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_user_cvjob_cv_job_id",
                table: "user",
                column: "cv_job_id",
                principalTable: "cvjob",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_role_role_id",
                table: "user",
                column: "role_id",
                principalTable: "role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_cvjob_cv_job_id",
                table: "user");

            migrationBuilder.DropForeignKey(
                name: "FK_user_role_role_id",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "user",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "user",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "otp_code",
                table: "user",
                newName: "otpcode");

            migrationBuilder.RenameColumn(
                name: "cv_job_id",
                table: "user",
                newName: "CVJobId");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "user",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_user_role_id",
                table: "user",
                newName: "IX_user_role");

            migrationBuilder.RenameIndex(
                name: "IX_user_cv_job_id",
                table: "user",
                newName: "IX_user_CVJobId");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 17, 2, 10, 14, DateTimeKind.Utc).AddTicks(191));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 17, 2, 10, 14, DateTimeKind.Utc).AddTicks(196));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 17, 2, 10, 14, DateTimeKind.Utc).AddTicks(197));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "password" },
                values: new object[] { new DateTime(2024, 10, 5, 17, 2, 10, 14, DateTimeKind.Utc).AddTicks(346), "AQAAAAEACSfAAAAAEOsNlVQvDhRnpqxyR5cXODN2ZI5N8WN4zcDc0Rr3rO+cag9vAoPH1hkeP7HeqbKsLw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_user_cvjob_CVJobId",
                table: "user",
                column: "CVJobId",
                principalTable: "cvjob",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_role_role",
                table: "user",
                column: "role",
                principalTable: "role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
