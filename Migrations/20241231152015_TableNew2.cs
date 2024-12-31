using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    /// <inheritdoc />
    public partial class TableNew2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    PublishedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72b1e17c-1b21-497c-8f3a-bf2204b6e560", "AQAAAAIAAYagAAAAEKgdbNEol3C6Z4RSHc0cy6EQn9rXhjqAghqG+FGFycf4bwI3616+ZiaZful+T2qZ7A==", "6d51316f-f742-4d0c-b926-d4f644051111" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "418e1a8d-b1c9-4ab7-bdf1-3030f2185f80", "AQAAAAIAAYagAAAAELWfiGO3phoFcZZs0UXt9IyY1ydM+1nhlYcTgZV5cWjU+1F7BA1DCJljnZeLLeGIzg==", "d22aee2f-818e-4ffb-aa2f-3309a7eac8de" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 11, 11, 18, 20, 15, 312, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 12, 11, 18, 20, 15, 312, DateTimeKind.Local).AddTicks(6880));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 11, 1, 18, 20, 15, 312, DateTimeKind.Local).AddTicks(6890));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

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
    }
}
