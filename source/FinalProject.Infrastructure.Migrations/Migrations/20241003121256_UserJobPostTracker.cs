using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UserJobPostTracker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAppliedJobsId",
                table: "jobpost",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "user_applied_jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_applied_jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_applied_jobs_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 3, 12, 12, 56, 496, DateTimeKind.Utc).AddTicks(6038));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 3, 12, 12, 56, 496, DateTimeKind.Utc).AddTicks(6047));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 3, 12, 12, 56, 496, DateTimeKind.Utc).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "password" },
                values: new object[] { new DateTime(2024, 10, 3, 12, 12, 56, 496, DateTimeKind.Utc).AddTicks(6171), "AQAAAAEACSfAAAAAEKmUlmZxvKsmilI6k9kJ5se2Xr73PsERRZiysFazNhH41UE001APv/KFm9h5kjM37A==" });

            migrationBuilder.CreateIndex(
                name: "IX_jobpost_UserAppliedJobsId",
                table: "jobpost",
                column: "UserAppliedJobsId");

            migrationBuilder.CreateIndex(
                name: "IX_user_applied_jobs_user_id",
                table: "user_applied_jobs",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_jobpost_user_applied_jobs_UserAppliedJobsId",
                table: "jobpost",
                column: "UserAppliedJobsId",
                principalTable: "user_applied_jobs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobpost_user_applied_jobs_UserAppliedJobsId",
                table: "jobpost");

            migrationBuilder.DropTable(
                name: "user_applied_jobs");

            migrationBuilder.DropIndex(
                name: "IX_jobpost_UserAppliedJobsId",
                table: "jobpost");

            migrationBuilder.DropColumn(
                name: "UserAppliedJobsId",
                table: "jobpost");

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
                columns: new[] { "CreatedDate", "password" },
                values: new object[] { new DateTime(2024, 9, 29, 11, 55, 15, 640, DateTimeKind.Utc).AddTicks(1014), "AQAAAAEACSfAAAAAEECtOLdKVQi630IGitQVXHUW0DOBSDnehbkJ3KRqN1NrzExVEk4DGPJAG/AWW5j7Zg==" });
        }
    }
}
