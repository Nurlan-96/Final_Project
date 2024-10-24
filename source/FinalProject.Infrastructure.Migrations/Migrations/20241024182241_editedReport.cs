using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class editedReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cvjob_cventity_CVEntityId",
                table: "cvjob");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.AlterColumn<int>(
                name: "CVEntityId",
                table: "cvjob",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    job_post_id = table.Column<int>(type: "integer", nullable: false),
                    JobPostEntityId = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_report_jobpost_JobPostEntityId",
                        column: x => x.JobPostEntityId,
                        principalTable: "jobpost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_report_user_user_id",
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

            migrationBuilder.CreateIndex(
                name: "IX_report_JobPostEntityId",
                table: "report",
                column: "JobPostEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_report_user_id",
                table: "report",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_cvjob_cventity_CVEntityId",
                table: "cvjob",
                column: "CVEntityId",
                principalTable: "cventity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cvjob_cventity_CVEntityId",
                table: "cvjob");

            migrationBuilder.DropTable(
                name: "report");

            migrationBuilder.AlterColumn<int>(
                name: "CVEntityId",
                table: "cvjob",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobPostEntityId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    JobPostId = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_jobpost_JobPostEntityId",
                        column: x => x.JobPostEntityId,
                        principalTable: "jobpost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 15, 19, 48, 49, 234, DateTimeKind.Utc).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 15, 19, 48, 49, 234, DateTimeKind.Utc).AddTicks(8429));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 15, 19, 48, 49, 234, DateTimeKind.Utc).AddTicks(8431));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_date", "password" },
                values: new object[] { new DateTime(2024, 10, 15, 19, 48, 49, 234, DateTimeKind.Utc).AddTicks(8587), "AQAAAAEACSfAAAAAEDM8PIQQ76aW7T9a7dxKpnorDg+ZP/2Efmo1A3Wo77ea2ROLsJRHIJgejZj3NN25NQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_JobPostEntityId",
                table: "Reports",
                column: "JobPostEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserId",
                table: "Reports",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_cvjob_cventity_CVEntityId",
                table: "cvjob",
                column: "CVEntityId",
                principalTable: "cventity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
