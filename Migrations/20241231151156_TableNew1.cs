using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    /// <inheritdoc />
    public partial class TableNew1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "598a4811-2b92-4f51-aab5-093f275ec73a", "AQAAAAIAAYagAAAAEGm0N7mosEBFxv4qhKAP46F4Pc3lGxCuElenUHmz0Nm3zMY56do5kpF7irL8HRholA==", "b69f2176-294c-4091-a083-02b0e11e383c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01713934-9081-48e6-b84d-1974f76bc5ff", "AQAAAAIAAYagAAAAEJxvUoOrNfCi7riLE0PPk1Vx1JqCuqu1o5i8xqtAYzCaeVuxLnq9nM6lp7aGYS8V1w==", "8ef21a80-e747-4a7d-a4b2-f942c6c81b8b" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 11, 11, 18, 11, 55, 948, DateTimeKind.Local).AddTicks(4330));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 12, 11, 18, 11, 55, 948, DateTimeKind.Local).AddTicks(4370));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 11, 1, 18, 11, 55, 948, DateTimeKind.Local).AddTicks(4370));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "614699d7-afbf-4068-a6cb-daebb17aef1b", "AQAAAAIAAYagAAAAEEFpQ0b5vOsyl0UbfuFV1JYYS+bCyZ1+m4g81YalRw+BKtCiZVFgmshWdTZjWid3+Q==", "0c3d490d-abf2-499b-8453-acbe403ca6fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77dc891d-eeaa-4e9a-b5fa-bc4e6a648fe3", "AQAAAAIAAYagAAAAEJUvmgM8bt3KM/Y43yY9zjj8HqJoZBLiFBH1rpmnGMFYeChSAP8GhEfwiOcVUvDxPg==", "8634591f-1f56-45d4-b694-ee940ee127b0" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 21, 18, 5, 56, 660, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 11, 20, 18, 5, 56, 660, DateTimeKind.Local).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 11, 18, 5, 56, 660, DateTimeKind.Local).AddTicks(4180));
        }
    }
}
