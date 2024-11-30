using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    /// <inheritdoc />
    public partial class NewTable5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbb34c8b-5796-4d02-9553-2bbf7865bbad", "AQAAAAIAAYagAAAAEN1Bzvx7q13ihzDKahY37JWHe3sIVE4ql+/c/TEvIVnHIiNm1+4PJrYsGbpk6V+IBA==", "01d007d6-8205-46ff-9248-4f7027ef5219" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ef13749-193c-413e-891b-0f79e1aa2cec", "AQAAAAIAAYagAAAAENF6yv2KE/AWLNSrf2WRfMQUbu1NyE36nBOVShxb4iFDe2pUBa8rLPo3p1GPXZ1zqw==", "7b199ab3-bb22-4e9b-8ff1-7a451ed531de" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 11, 19, 3, 58, 343, DateTimeKind.Local).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 11, 10, 19, 3, 58, 343, DateTimeKind.Local).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 1, 19, 3, 58, 343, DateTimeKind.Local).AddTicks(9520));
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
