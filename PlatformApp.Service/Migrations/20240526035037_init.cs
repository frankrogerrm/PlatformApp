using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlatformApp.Service.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductPrice = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address", "CreatedDate", "FirstName", "LastName", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Suite 405 352 Waelchi Mission, Bednarhaven, AK 15529", new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(346), "Symone", "Tobias", true, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(358) },
                    { 2, "17279 Herman Trail, Oberbrunnerland, VA 04806", new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(360), "Josefina", "Mayfield", true, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(361) },
                    { 3, "Suite 934 4384 Sean Trace, Port Carrolport, SC 53835", new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(362), "Luke", "Garrett", true, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(363) },
                    { 4, "Apt. 460 560 Powlowski Pike, New Shelaside, MN 74288-8673", new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(365), "Santana", "Bergeron", true, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(365) },
                    { 5, "169 McLaughlin Viaduct, Wisokyton, VA 74079", new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(367), "Allen", "Rollins", true, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(368) }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CreatedDate", "CustomerId", "ProductDescription", "ProductName", "ProductPrice", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(536), 1, "synthesizer", "First Korg synthesizer", 10L, true, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(537) },
                    { 2, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(540), 1, "preset synthesizers", "Full polyphonic preset synthesizers", 20L, true, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(541) },
                    { 3, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(543), 2, "First Product", "Rhythm machine,", 30L, true, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(544) },
                    { 4, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(546), 2, "Key Punch", "Motor Drive Duplicating Key Punch", 40L, true, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(546) },
                    { 5, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(548), 3, "synthesizer", "First Korg synthesizer", 50L, true, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(549) },
                    { 6, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(551), 3, "Proof punch", "Printing Card Proof Punch", 50L, true, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(552) },
                    { 7, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(553), 4, "Accounting Machine", "Electric Accounting Machine", 10L, true, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(554) },
                    { 8, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(556), 4, "Tabulating model ", "Alphabetic Tabulating model ", 40L, true, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(557) },
                    { 9, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(559), 5, "TypeWriter", "IBM 870 Non-transmitting Typewriter", 30L, true, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(559) },
                    { 10, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(561), 5, "fire-control instruments", "Aircraft and naval fire-control instruments", 20L, true, new DateTime(2024, 5, 25, 21, 50, 37, 113, DateTimeKind.Local).AddTicks(562) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
