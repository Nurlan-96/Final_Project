using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class addedUserAppliedJobs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobpost_user_applied_jobs_UserAppliedJobsId",
                table: "jobpost");

            migrationBuilder.RenameColumn(
                name: "UserAppliedJobsId",
                table: "jobpost",
                newName: "UserAppliedJobId");

            migrationBuilder.RenameIndex(
                name: "IX_jobpost_UserAppliedJobsId",
                table: "jobpost",
                newName: "IX_jobpost_UserAppliedJobId");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 18, 36, 15, 398, DateTimeKind.Utc).AddTicks(5596));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 18, 36, 15, 398, DateTimeKind.Utc).AddTicks(5603));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 5, 18, 36, 15, 398, DateTimeKind.Utc).AddTicks(5604));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_date", "password" },
                values: new object[] { new DateTime(2024, 10, 5, 18, 36, 15, 398, DateTimeKind.Utc).AddTicks(5745), "AQAAAAEACSfAAAAAEPYQGGuZlIcd6EUJdaLvEw+IXabddq3DFR94LYtmTpNJwg5C7vr8G4jP1DZgMn8XqA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_jobpost_user_applied_jobs_UserAppliedJobId",
                table: "jobpost",
                column: "UserAppliedJobId",
                principalTable: "user_applied_jobs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobpost_user_applied_jobs_UserAppliedJobId",
                table: "jobpost");

            migrationBuilder.RenameColumn(
                name: "UserAppliedJobId",
                table: "jobpost",
                newName: "UserAppliedJobsId");

            migrationBuilder.RenameIndex(
                name: "IX_jobpost_UserAppliedJobId",
                table: "jobpost",
                newName: "IX_jobpost_UserAppliedJobsId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_jobpost_user_applied_jobs_UserAppliedJobsId",
                table: "jobpost",
                column: "UserAppliedJobsId",
                principalTable: "user_applied_jobs",
                principalColumn: "Id");
        }
    }
}
