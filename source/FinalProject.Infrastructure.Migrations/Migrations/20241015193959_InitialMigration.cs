using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cventity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    desciption = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    expctedsalary = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    education = table.Column<int>(type: "integer", nullable: false),
                    city = table.Column<int>(type: "integer", nullable: false),
                    experience = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cventity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cvjob",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    company_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    desciption = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    city = table.Column<int>(type: "integer", nullable: false),
                    CVEntityId = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cvjob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cvjob_cventity_CVEntityId",
                        column: x => x.CVEntityId,
                        principalTable: "cventity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    cv_job_id = table.Column<int>(type: "integer", nullable: true),
                    CVEntityId = table.Column<int>(type: "integer", nullable: false),
                    is_banned = table.Column<bool>(type: "boolean", nullable: false),
                    otp_code = table.Column<string>(type: "text", nullable: true),
                    allow_change_with_otp = table.Column<bool>(type: "boolean", nullable: false),
                    otp_expireation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    refresh_token = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_cventity_CVEntityId",
                        column: x => x.CVEntityId,
                        principalTable: "cventity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_cvjob_cv_job_id",
                        column: x => x.cv_job_id,
                        principalTable: "cvjob",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_company_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "jobpost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    desciption = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    requirements = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    salary = table.Column<int>(type: "integer", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    City = table.Column<int>(type: "integer", nullable: false),
                    education = table.Column<int>(type: "integer", nullable: false),
                    EmploymentType = table.Column<int>(type: "integer", nullable: false),
                    experience = table.Column<int>(type: "integer", nullable: false),
                    exp_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserAppliedJobId = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobpost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobpost_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobpost_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobpost_user_applied_jobs_UserAppliedJobId",
                        column: x => x.UserAppliedJobId,
                        principalTable: "user_applied_jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    JobPostId = table.Column<int>(type: "integer", nullable: false),
                    JobPostEntityId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "CreatedDate", "name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 15, 19, 39, 59, 558, DateTimeKind.Utc).AddTicks(4388), "SuperAdmin" },
                    { 2, new DateTime(2024, 10, 15, 19, 39, 59, 558, DateTimeKind.Utc).AddTicks(4393), "User" },
                    { 3, new DateTime(2024, 10, 15, 19, 39, 59, 558, DateTimeKind.Utc).AddTicks(4395), "Company" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_category_name",
                table: "category",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_company_email",
                table: "company",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_company_name",
                table: "company",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_company_user_id",
                table: "company",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cventity_email",
                table: "cventity",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cvjob_CVEntityId",
                table: "cvjob",
                column: "CVEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_jobpost_CategoryId",
                table: "jobpost",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_jobpost_CompanyId",
                table: "jobpost",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_jobpost_UserAppliedJobId",
                table: "jobpost",
                column: "UserAppliedJobId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_JobPostEntityId",
                table: "Reports",
                column: "JobPostEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserId",
                table: "Reports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_role_name",
                table: "role",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_cv_job_id",
                table: "user",
                column: "cv_job_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_CVEntityId",
                table: "user",
                column: "CVEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_user_email",
                table: "user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_phone_number",
                table: "user",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_refresh_token",
                table: "user",
                column: "refresh_token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_role_id",
                table: "user",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_applied_jobs_user_id",
                table: "user_applied_jobs",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "jobpost");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "user_applied_jobs");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "cvjob");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "cventity");
        }
    }
}
