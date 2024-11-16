using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "322e99e4-352f-49e8-8f57-6b3dc333b9ef", "AQAAAAIAAYagAAAAELr7rslr3EQSx7c/S+yhmtUPopqTnkdnLK836cvj8ZlkiF3sDtb9m1rUedRfxJyJ1w==", "8825191d-9d58-458e-8580-8ca0ad832cc8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28f425fa-c6c4-4149-b53b-80fa79810f6e", "AQAAAAIAAYagAAAAEGnA/oGWM8hufxx5qSDbilKaEmRyWn02F/xcQYAwOb50/Is/Txe6R4uEyf1UXQesfA==", "cb12da79-6292-440f-b2c5-3c0b1d207669" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Telefonlar" },
                    { 2, "Bilgisayarlar" },
                    { 3, "Aksesuarlar" }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                columns: new[] { "CategoryId", "PublishedOn" },
                values: new object[] { 1, new DateTime(2024, 9, 26, 18, 48, 21, 416, DateTimeKind.Local).AddTicks(320) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                columns: new[] { "CategoryId", "PublishedOn" },
                values: new object[] { 1, new DateTime(2024, 10, 26, 18, 48, 21, 416, DateTimeKind.Local).AddTicks(340) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                columns: new[] { "CategoryId", "PublishedOn" },
                values: new object[] { 1, new DateTime(2024, 9, 16, 18, 48, 21, 416, DateTimeKind.Local).AddTicks(350) });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f83b517b-bc73-4425-9f96-3f500cbd6d78", "AQAAAAIAAYagAAAAENcy03639NSg8mE+G0LjAlKt1ZoqQwunn6PTlY9hqXDg0FLu+YBtUAfZrNnKfKb3pw==", "00f3840b-ba15-409a-b427-548109eb61d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "647f8d34-91a8-4242-8910-cc009777a75f", "AQAAAAIAAYagAAAAEOtxvNRpQVWwP9E11/cFFMEF1SIZppMuNql42AcVIdCtBwcRvFiOXJgQXYmTp66nSA==", "f3144a19-f561-41da-a0ed-1f5e00ef8ee8" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 9, 25, 19, 0, 7, 309, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 10, 25, 19, 0, 7, 309, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 9, 15, 19, 0, 7, 309, DateTimeKind.Local).AddTicks(9100));
        }
    }
}
