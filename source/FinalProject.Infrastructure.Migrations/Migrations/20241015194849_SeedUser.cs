using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class SeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_cventity_CVEntityId",
                table: "user");

            migrationBuilder.AlterColumn<int>(
                name: "CVEntityId",
                table: "user",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "allow_change_with_otp", "CVEntityId", "cv_job_id", "created_date", "email", "name", "is_banned", "otp_code", "otp_expireation_date", "password", "phone_number", "refresh_token", "role_id", "updated_date" },
                values: new object[] { 1, false, null, null, new DateTime(2024, 10, 15, 19, 48, 49, 234, DateTimeKind.Utc).AddTicks(8587), "alex@example.com", "Alex Mercer", false, null, null, "AQAAAAEACSfAAAAAEDM8PIQQ76aW7T9a7dxKpnorDg+ZP/2Efmo1A3Wo77ea2ROLsJRHIJgejZj3NN25NQ==", "000000", null, 1, null });

            migrationBuilder.AddForeignKey(
                name: "FK_user_cventity_CVEntityId",
                table: "user",
                column: "CVEntityId",
                principalTable: "cventity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_cventity_CVEntityId",
                table: "user");

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "CVEntityId",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 15, 19, 39, 59, 558, DateTimeKind.Utc).AddTicks(4388));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 15, 19, 39, 59, 558, DateTimeKind.Utc).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 15, 19, 39, 59, 558, DateTimeKind.Utc).AddTicks(4395));

            migrationBuilder.AddForeignKey(
                name: "FK_user_cventity_CVEntityId",
                table: "user",
                column: "CVEntityId",
                principalTable: "cventity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
