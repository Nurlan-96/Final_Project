using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class addedCVSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_jobpost_name",
                table: "jobpost");

            migrationBuilder.RenameColumn(
                name: "refreshtoken",
                table: "user",
                newName: "refresh_token");

            migrationBuilder.RenameColumn(
                name: "otpexpireationdate",
                table: "user",
                newName: "otp_expireation_date");

            migrationBuilder.RenameColumn(
                name: "allowchangewithotp",
                table: "user",
                newName: "allow_change_with_otp");

            migrationBuilder.AddColumn<int>(
                name: "CVJobId",
                table: "user",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "cventity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phonenumber = table.Column<string>(type: "text", nullable: false),
                    desciption = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    expctedsalary = table.Column<int>(type: "integer", nullable: false),
                    education = table.Column<int>(type: "integer", nullable: false),
                    city = table.Column<int>(type: "integer", nullable: false),
                    EmploymentType = table.Column<int>(type: "integer", nullable: false),
                    experience = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cventity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cvjob",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    companyname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    desciption = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    city = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cvjob", x => x.Id);
                });

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
                columns: new[] { "CVJobId", "CreatedDate", "password" },
                values: new object[] { null, new DateTime(2024, 10, 5, 17, 2, 10, 14, DateTimeKind.Utc).AddTicks(346), "AQAAAAEACSfAAAAAEOsNlVQvDhRnpqxyR5cXODN2ZI5N8WN4zcDc0Rr3rO+cag9vAoPH1hkeP7HeqbKsLw==" });

            migrationBuilder.CreateIndex(
                name: "IX_user_CVJobId",
                table: "user",
                column: "CVJobId");

            migrationBuilder.CreateIndex(
                name: "IX_user_refresh_token",
                table: "user",
                column: "refresh_token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cventity_email",
                table: "cventity",
                column: "email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_user_cvjob_CVJobId",
                table: "user",
                column: "CVJobId",
                principalTable: "cvjob",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_cvjob_CVJobId",
                table: "user");

            migrationBuilder.DropTable(
                name: "cventity");

            migrationBuilder.DropTable(
                name: "cvjob");

            migrationBuilder.DropIndex(
                name: "IX_user_CVJobId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_refresh_token",
                table: "user");

            migrationBuilder.DropColumn(
                name: "CVJobId",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "refresh_token",
                table: "user",
                newName: "refreshtoken");

            migrationBuilder.RenameColumn(
                name: "otp_expireation_date",
                table: "user",
                newName: "otpexpireationdate");

            migrationBuilder.RenameColumn(
                name: "allow_change_with_otp",
                table: "user",
                newName: "allowchangewithotp");

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
                name: "IX_jobpost_name",
                table: "jobpost",
                column: "name",
                unique: true);
        }
    }
}
