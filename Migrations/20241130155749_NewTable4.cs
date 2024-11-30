using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.Migrations
{
    /// <inheritdoc />
    public partial class NewTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    AddressLine = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Posts_PostId",
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
                columns: new[] { "Price", "PublishedOn" },
                values: new object[] { 45000m, new DateTime(2024, 10, 11, 18, 57, 49, 375, DateTimeKind.Local).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                columns: new[] { "Price", "PublishedOn" },
                values: new object[] { 55000m, new DateTime(2024, 11, 10, 18, 57, 49, 375, DateTimeKind.Local).AddTicks(8740) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                columns: new[] { "Price", "PublishedOn" },
                values: new object[] { 75000m, new DateTime(2024, 10, 1, 18, 57, 49, 375, DateTimeKind.Local).AddTicks(8740) });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PostId",
                table: "OrderItems",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "ImageFile", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "0da635fb-1c7d-4074-8739-a5d546648637", "ApplicationUser", "info@gmail.com", true, "Ömer Apaydın", "p1.jpg", false, null, null, null, "AQAAAAIAAYagAAAAEC1r579En6MfPIFwRTdyi0lBaxGj1JDVwQRg56+s4oheUNobhQG4suinUpKS/o23KA==", null, false, "c2d68d7d-ea63-49e9-8167-3d501fac9d25", false, "omerapaydin" },
                    { "2", 0, "0a5a2d16-46d3-4b31-a7d1-0cd83d6be2c8", "ApplicationUser", "info2@gmail.com", true, "Ahmet Tamboğa", "p2.jpg", false, null, null, null, "AQAAAAIAAYagAAAAEMh2/JDMOT+bighn1DnUWbwz2GR1qTKmEZDtVcEPpESOG1cdu9KQN/T6jhPTFVDypQ==", null, false, "1124aed1-a528-4873-b3a3-3cadc19fe20d", false, "ahmettambuga" }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                columns: new[] { "Price", "PublishedOn" },
                values: new object[] { "45000", new DateTime(2024, 10, 1, 18, 55, 21, 265, DateTimeKind.Local).AddTicks(2150) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                columns: new[] { "Price", "PublishedOn" },
                values: new object[] { "55000", new DateTime(2024, 10, 31, 18, 55, 21, 265, DateTimeKind.Local).AddTicks(2190) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                columns: new[] { "Price", "PublishedOn" },
                values: new object[] { "75000", new DateTime(2024, 9, 21, 18, 55, 21, 265, DateTimeKind.Local).AddTicks(2190) });
        }
    }
}
