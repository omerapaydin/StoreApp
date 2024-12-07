using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    /// <inheritdoc />
    public partial class TableNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf07a43a-1e6f-4de0-a192-f35b0c5fa415", "AQAAAAIAAYagAAAAEDG00Vtyh/945XrmJzracmGK3+Tr1TYtv07pbB41ejvueyeiOjGOV6u1ynEjfU0gMg==", "bd9e3246-212f-4ac3-b3f0-7a29559ec9f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c5ad155-e6e0-4f5c-bc27-6dbc92fafa9f", "AQAAAAIAAYagAAAAEKhtSt1U9iW2AlztrAK1XtmK+U/EXmzhBVPH7fQc4FtAIwmpeNkqFUJr5EDy12PnPw==", "cf3e81e0-808d-4c95-9bbe-daffd27783eb" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 11, 18, 57, 49, 375, DateTimeKind.Local).AddTicks(8700));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 11, 10, 18, 57, 49, 375, DateTimeKind.Local).AddTicks(8740));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 1, 18, 57, 49, 375, DateTimeKind.Local).AddTicks(8740));
        }
    }
}
