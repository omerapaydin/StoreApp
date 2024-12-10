using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    /// <inheritdoc />
    public partial class Tables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1039e146-4ffe-49f8-acbb-c4840213d288", "AQAAAAIAAYagAAAAEPpi+2d5GdBRi6xtlDLjzHHz/vNUqVTowSsTVbP98kkpB9aQTshg1flHutKSu54UTw==", "2c0cdf93-b049-4e40-a02d-ca9368322e3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d3fb39c-d90a-44c6-a3d8-3993e6bf42b4", "AQAAAAIAAYagAAAAELFqju9SUKi/woU5bbIExt5ZbOqfYkOsaoAGfjZmNYlIC/fmsREyYaJYyEFnuATKtw==", "a5685d10-168e-4023-9b33-28c122c68a3a" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 18, 20, 51, 15, 982, DateTimeKind.Local).AddTicks(8310));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 11, 17, 20, 51, 15, 982, DateTimeKind.Local).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 8, 20, 51, 15, 982, DateTimeKind.Local).AddTicks(8350));
        }
    }
}
