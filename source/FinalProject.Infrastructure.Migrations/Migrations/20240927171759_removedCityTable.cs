using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class removedCityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobpost_city_city_id",
                table: "jobpost");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropIndex(
                name: "IX_jobpost_city_id",
                table: "jobpost");

            migrationBuilder.RenameColumn(
                name: "city_id",
                table: "jobpost",
                newName: "City");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "jobpost",
                newName: "city_id");

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 23, 19, 0, 27, 810, DateTimeKind.Utc).AddTicks(1333));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 23, 19, 0, 27, 810, DateTimeKind.Utc).AddTicks(1339));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 23, 19, 0, 27, 810, DateTimeKind.Utc).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "password" },
                values: new object[] { new DateTime(2024, 9, 23, 19, 0, 27, 810, DateTimeKind.Utc).AddTicks(1477), "AQAAAAEACSfAAAAAEBbWs4xACSTqqRgmrn8dyEHw3SfnkADU0QQmwyb+R3xxgATDB2Rk0lHb76FJmkKctA==" });

            migrationBuilder.CreateIndex(
                name: "IX_jobpost_city_id",
                table: "jobpost",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_city_name",
                table: "city",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_jobpost_city_city_id",
                table: "jobpost",
                column: "city_id",
                principalTable: "city",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
