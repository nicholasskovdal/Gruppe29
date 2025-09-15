using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dive_Deep.Migrations
{
    /// <inheritdoc />
    public partial class InitManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerDay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "BCDs",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sizes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCDs", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_BCDs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DivingSuits",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sizes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thickness = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivingSuits", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_DivingSuits_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Finns",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sizes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finns", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Finns_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaskSnorkels",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaskSnorkels", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_MaskSnorkels_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductBookings",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBookings", x => new { x.ProductId, x.BookingId });
                    table.ForeignKey(
                        name: "FK_ProductBookings_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductBookings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegulatorSets",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    FirstStep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondStep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Octopus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegulatorSets", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_RegulatorSets_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tanks",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Tanks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Brand", "PricePerDay" },
                values: new object[,]
                {
                    { 1, "Scubapro", 125 },
                    { 2, "Scubapro", 125 },
                    { 3, "Scubapro", 125 },
                    { 4, "Scubapro", 140 },
                    { 5, "Scubapro", 140 },
                    { 6, "Scubapro", 140 },
                    { 7, "Scubapro", 200 },
                    { 8, "Scubapro", 200 },
                    { 9, "Scubapro", 200 },
                    { 10, "Seac", 145 },
                    { 11, "Seac", 145 },
                    { 12, "Seac", 145 },
                    { 13, "Scubapro", 100 },
                    { 14, "Scubapro", 100 },
                    { 15, "Scubapro", 100 },
                    { 16, "Scubapro", 100 },
                    { 17, "Scubapro", 100 },
                    { 18, "Scubapro", 100 },
                    { 19, "Scubapro", 100 },
                    { 20, "Scubapro", 100 },
                    { 21, "Scubapro", 100 },
                    { 22, "Scubapro", 100 },
                    { 23, "Scubapro", 100 },
                    { 24, "Scubapro", 100 },
                    { 25, "Scubapro", 100 },
                    { 26, "Scubapro", 100 },
                    { 27, "Scubapro", 100 },
                    { 28, "Scubapro", 100 },
                    { 29, "Scubapro", 100 },
                    { 30, "Scubapro", 100 },
                    { 31, "Scubapro", 100 },
                    { 32, "Scubapro", 100 },
                    { 33, "Scubapro", 100 },
                    { 34, "Scubapro", 100 },
                    { 35, "Scubapro", 100 },
                    { 36, "Scubapro", 100 },
                    { 37, "Scubapro", 100 },
                    { 38, "Scubapro", 100 },
                    { 39, "Scubapro", 100 },
                    { 40, "Scubapro", 100 },
                    { 41, "Scubapro", 100 },
                    { 42, "Scubapro", 100 },
                    { 43, "Waterproof", 100 },
                    { 44, "Waterproof", 100 },
                    { 45, "Waterproof", 100 },
                    { 46, "Waterproof", 100 },
                    { 47, "Waterproof", 100 },
                    { 48, "Waterproof", 100 },
                    { 49, "Waterproof", 100 },
                    { 50, "Waterproof", 100 },
                    { 51, "Waterproof", 100 },
                    { 52, "Waterproof", 100 },
                    { 53, "Fourth Element", 120 },
                    { 54, "Fourth Element", 120 },
                    { 55, "Fourth Element", 120 },
                    { 56, "Fourth Element", 120 },
                    { 57, "Fourth Element", 120 },
                    { 58, "Fourth Element", 120 },
                    { 59, "Fourth Element", 120 },
                    { 60, "Fourth Element", 120 },
                    { 61, "Fourth Element", 120 },
                    { 62, "Fourth Element", 120 },
                    { 63, "Scubapro", 300 },
                    { 64, "Scubapro", 300 },
                    { 65, "Scubapro", 300 },
                    { 66, "Scubapro", 300 },
                    { 67, "Scubapro", 300 },
                    { 68, "Scubapro", 300 },
                    { 69, "Scubapro", 300 },
                    { 70, "Scubapro", 300 },
                    { 71, "Scubapro", 300 },
                    { 72, "Scubapro", 300 },
                    { 73, "Waterproof", 320 },
                    { 74, "Waterproof", 320 },
                    { 75, "Waterproof", 320 },
                    { 76, "Waterproof", 320 },
                    { 77, "Waterproof", 320 },
                    { 78, "Waterproof", 320 },
                    { 79, "Waterproof", 320 },
                    { 80, "Waterproof", 320 },
                    { 81, "Waterproof", 320 },
                    { 82, "Waterproof", 320 },
                    { 83, "Santi", 350 },
                    { 84, "Santi", 350 },
                    { 85, "Santi", 350 },
                    { 86, "Santi", 350 },
                    { 87, "Santi", 350 },
                    { 88, "Santi", 350 },
                    { 89, "Santi", 350 },
                    { 90, "Santi", 350 },
                    { 91, "Santi", 350 },
                    { 92, "Santi", 350 },
                    { 93, "Scubapro", 150 },
                    { 94, "Scubapro", 160 },
                    { 95, "Scubapro", 170 },
                    { 96, "Scubapro", 180 },
                    { 97, "Scubapro", 125 },
                    { 98, "Scubapro", 100 },
                    { 99, "Scubapro", 150 },
                    { 100, "Scubapro", 50 },
                    { 101, "Scubapro", 60 },
                    { 102, "Scubapro", 50 },
                    { 103, "Scubapro", 75 },
                    { 104, "Fourth Element", 75 },
                    { 105, "Fourth Element", 75 },
                    { 106, "Tusa", 75 },
                    { 107, "Scubapro", 50 },
                    { 108, "Scubapro", 50 },
                    { 109, "Scubapro", 50 },
                    { 110, "Scubapro", 50 },
                    { 111, "Scubapro", 50 },
                    { 112, "Scubapro", 50 },
                    { 113, "Scubapro", 50 },
                    { 114, "Scubapro", 50 },
                    { 115, "Scubapro", 50 },
                    { 116, "Scubapro", 50 },
                    { 117, "Scubapro", 60 },
                    { 118, "Scubapro", 60 },
                    { 119, "Scubapro", 60 },
                    { 120, "Scubapro", 60 },
                    { 121, "Scubapro", 60 },
                    { 122, "Seac", 50 },
                    { 123, "Seac", 50 },
                    { 124, "Seac", 50 },
                    { 125, "Seac", 50 },
                    { 126, "Seac", 50 },
                    { 127, "Seac", 50 },
                    { 128, "Seac", 50 },
                    { 129, "Seac", 50 },
                    { 130, "Seac", 50 },
                    { 131, "Seac", 50 },
                    { 132, "Fourth Element", 75 },
                    { 133, "Fourth Element", 75 },
                    { 134, "Fourth Element", 75 },
                    { 135, "Fourth Element", 75 },
                    { 136, "Fourth Element", 75 },
                    { 137, "Fourth Element", 80 },
                    { 138, "Fourth Element", 80 },
                    { 139, "Fourth Element", 80 },
                    { 140, "Fourth Element", 80 },
                    { 141, "Fourth Element", 80 }
                });

            migrationBuilder.InsertData(
                table: "BCDs",
                columns: new[] { "ProductId", "Model", "Sizes" },
                values: new object[,]
                {
                    { 1, "Navigator Lite BCD", "S" },
                    { 2, "Navigator Lite BCD", "M" },
                    { 3, "Navigator Lite BCD", "L" },
                    { 4, "BCD Glide", "S" },
                    { 5, "BCD Glide", "M" },
                    { 6, "BCD Glide", "L" },
                    { 7, "BCD Hydros Pro", "S" },
                    { 8, "BCD Hydros Pro", "M" },
                    { 9, "BCD Hydros Pro", "L" },
                    { 10, "BCD Modular", "S" },
                    { 11, "BCD Modular", "M" },
                    { 12, "BCD Modular", "L" }
                });

            migrationBuilder.InsertData(
                table: "DivingSuits",
                columns: new[] { "ProductId", "Gender", "Model", "Sizes", "Thickness", "Type" },
                values: new object[,]
                {
                    { 13, "Herre", "Definition", "XS", 3f, "Våddragt" },
                    { 14, "Dame", "Definition", "XS", 3f, "Våddragt" },
                    { 15, "Herre", "Definition", "XS", 5f, "Våddragt" },
                    { 16, "Dame", "Definition", "XS", 5f, "Våddragt" },
                    { 17, "Herre", "Definition", "XS", 7f, "Våddragt" },
                    { 18, "Dame", "Definition", "XS", 7f, "Våddragt" },
                    { 19, "Herre", "Definition", "S", 3f, "Våddragt" },
                    { 20, "Dame", "Definition", "S", 3f, "Våddragt" },
                    { 21, "Herre", "Definition", "S", 5f, "Våddragt" },
                    { 22, "Dame", "Definition", "S", 5f, "Våddragt" },
                    { 23, "Herre", "Definition", "S", 7f, "Våddragt" },
                    { 24, "Dame", "Definition", "S", 7f, "Våddragt" },
                    { 25, "Herre", "Definition", "M", 3f, "Våddragt" },
                    { 26, "Dame", "Definition", "M", 3f, "Våddragt" },
                    { 27, "Herre", "Definition", "M", 5f, "Våddragt" },
                    { 28, "Dame", "Definition", "M", 5f, "Våddragt" },
                    { 29, "Herre", "Definition", "M", 7f, "Våddragt" },
                    { 30, "Dame", "Definition", "M", 7f, "Våddragt" },
                    { 31, "Herre", "Definition", "L", 3f, "Våddragt" },
                    { 32, "Dame", "Definition", "L", 3f, "Våddragt" },
                    { 33, "Herre", "Definition", "L", 5f, "Våddragt" },
                    { 34, "Dame", "Definition", "L", 5f, "Våddragt" },
                    { 35, "Herre", "Definition", "L", 7f, "Våddragt" },
                    { 36, "Dame", "Definition", "L", 7f, "Våddragt" },
                    { 37, "Herre", "Definition", "XL", 3f, "Våddragt" },
                    { 38, "Dame", "Definition", "XL", 3f, "Våddragt" },
                    { 39, "Herre", "Definition", "XL", 5f, "Våddragt" },
                    { 40, "Dame", "Definition", "XL", 5f, "Våddragt" },
                    { 41, "Herre", "Definition", "XL", 7f, "Våddragt" },
                    { 42, "Dame", "Definition", "XL", 7f, "Våddragt" },
                    { 43, "Herre", "W5", "XS", 3.5f, "Våddragt" },
                    { 44, "Dame", "W5", "XS", 3.5f, "Våddragt" },
                    { 45, "Herre", "W5", "S", 3.5f, "Våddragt" },
                    { 46, "Dame", "W5", "S", 3.5f, "Våddragt" },
                    { 47, "Herre", "W5", "M", 3.5f, "Våddragt" },
                    { 48, "Dame", "W5", "M", 3.5f, "Våddragt" },
                    { 49, "Herre", "W5", "L", 3.5f, "Våddragt" },
                    { 50, "Dame", "W5", "L", 3.5f, "Våddragt" },
                    { 51, "Herre", "W5", "XL", 3.5f, "Våddragt" },
                    { 52, "Dame", "W5", "XL", 3.5f, "Våddragt" },
                    { 53, "Herre", "Proteus", "XS", 5f, "Våddragt" },
                    { 54, "Dame", "Proteus", "XS", 5f, "Våddragt" },
                    { 55, "Herre", "Proteus", "S", 5f, "Våddragt" },
                    { 56, "Dame", "Proteus", "S", 5f, "Våddragt" },
                    { 57, "Herre", "Proteus", "M", 5f, "Våddragt" },
                    { 58, "Dame", "Proteus", "M", 5f, "Våddragt" },
                    { 59, "Herre", "Proteus", "L", 5f, "Våddragt" },
                    { 60, "Dame", "Proteus", "L", 5f, "Våddragt" },
                    { 61, "Herre", "Proteus", "XL", 5f, "Våddragt" },
                    { 62, "Dame", "Proteus", "XL", 5f, "Våddragt" },
                    { 63, "Herre", "Exodry 4.0", "XS", null, "Tordragt" },
                    { 64, "Dame", "Exodry 4.0", "XS", null, "Tordragt" },
                    { 65, "Herre", "Exodry 4.0", "S", null, "Tordragt" },
                    { 66, "Dame", "Exodry 4.0", "S", null, "Tordragt" },
                    { 67, "Herre", "Exodry 4.0", "M", null, "Tordragt" },
                    { 68, "Dame", "Exodry 4.0", "M", null, "Tordragt" },
                    { 69, "Herre", "Exodry 4.0", "L", null, "Tordragt" },
                    { 70, "Dame", "Exodry 4.0", "L", null, "Tordragt" },
                    { 71, "Herre", "Exodry 4.0", "XL", null, "Tordragt" },
                    { 72, "Dame", "Exodry 4.0", "XL", null, "Tordragt" },
                    { 73, "Herre", "D7 Evo", "XS", null, "Tordragt" },
                    { 74, "Dame", "D7 Evo", "XS", null, "Tordragt" },
                    { 75, "Herre", "D7 Evo", "S", null, "Tordragt" },
                    { 76, "Dame", "D7 Evo", "S", null, "Tordragt" },
                    { 77, "Herre", "D7 Evo", "M", null, "Tordragt" },
                    { 78, "Dame", "D7 Evo", "M", null, "Tordragt" },
                    { 79, "Herre", "D7 Evo", "L", null, "Tordragt" },
                    { 80, "Dame", "D7 Evo", "L", null, "Tordragt" },
                    { 81, "Herre", "D7 Evo", "XL", null, "Tordragt" },
                    { 82, "Dame", "D7 Evo", "XL", null, "Tordragt" },
                    { 83, "Herre", "E.Lite Plus", "XS", null, "Tordragt" },
                    { 84, "Dame", "E.Lite Plus", "XS", null, "Tordragt" },
                    { 85, "Herre", "E.Lite Plus", "S", null, "Tordragt" },
                    { 86, "Dame", "E.Lite Plus", "S", null, "Tordragt" },
                    { 87, "Herre", "E.Lite Plus", "M", null, "Tordragt" },
                    { 88, "Dame", "E.Lite Plus", "M", null, "Tordragt" },
                    { 89, "Herre", "E.Lite Plus", "L", null, "Tordragt" },
                    { 90, "Dame", "E.Lite Plus", "L", null, "Tordragt" },
                    { 91, "Herre", "E.Lite Plus", "XL", null, "Tordragt" },
                    { 92, "Dame", "E.Lite Plus", "XL", null, "Tordragt" }
                });

            migrationBuilder.InsertData(
                table: "Finns",
                columns: new[] { "ProductId", "Model", "Sizes" },
                values: new object[,]
                {
                    { 107, "Jet Fin", "XS" },
                    { 108, "Jet Fin", "S" },
                    { 109, "Jet Fin", "M" },
                    { 110, "Jet Fin", "L" },
                    { 111, "Jet Fin", "XL" },
                    { 112, "GO Travel", "XS" },
                    { 113, "GO Travel", "S" },
                    { 114, "GO Travel", "M" },
                    { 115, "GO Travel", "L" },
                    { 116, "GO Travel", "XL" },
                    { 117, "Seawing Supernova", "XS" },
                    { 118, "Seawing Supernova", "S" },
                    { 119, "Seawing Supernova", "M" },
                    { 120, "Seawing Supernova", "L" },
                    { 121, "Seawing Supernova", "XL" },
                    { 122, "Propulsion", "XS" },
                    { 123, "Propulsion", "S" },
                    { 124, "Propulsion", "M" },
                    { 125, "Propulsion", "L" },
                    { 126, "Propulsion", "XL" },
                    { 127, "ALA", "XS" },
                    { 128, "ALA", "S" },
                    { 129, "ALA", "M" },
                    { 130, "ALA", "L" },
                    { 131, "ALA", "XL" },
                    { 132, "Tech", "XS" },
                    { 133, "Tech", "S" },
                    { 134, "Tech", "M" },
                    { 135, "Tech", "L" },
                    { 136, "Tech", "XL" },
                    { 137, "Rec Fin", "XS" },
                    { 138, "Rec Fin", "S" },
                    { 139, "Rec Fin", "M" },
                    { 140, "Rec Fin", "L" },
                    { 141, "Rec Fin", "XL" }
                });

            migrationBuilder.InsertData(
                table: "MaskSnorkels",
                columns: new[] { "ProductId", "Model" },
                values: new object[,]
                {
                    { 100, "Ghost" },
                    { 101, "D-Mask" },
                    { 102, "Spectra Mini" },
                    { 103, "Crystal VU" },
                    { 104, "Scout Kontrast" },
                    { 105, "Scout Enhance" },
                    { 106, "Element" }
                });

            migrationBuilder.InsertData(
                table: "RegulatorSets",
                columns: new[] { "ProductId", "FirstStep", "Octopus", "SecondStep" },
                values: new object[,]
                {
                    { 97, "MK25EVO", "R105", "S600" },
                    { 98, "MK17EVO", "R095", "C370" },
                    { 99, "MK25EVO BT", "S270", "A700 Carbon BT" }
                });

            migrationBuilder.InsertData(
                table: "Tanks",
                columns: new[] { "ProductId", "Volume" },
                values: new object[,]
                {
                    { 93, 5 },
                    { 94, 10 },
                    { 95, 12 },
                    { 96, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductBookings_BookingId",
                table: "ProductBookings",
                column: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BCDs");

            migrationBuilder.DropTable(
                name: "DivingSuits");

            migrationBuilder.DropTable(
                name: "Finns");

            migrationBuilder.DropTable(
                name: "MaskSnorkels");

            migrationBuilder.DropTable(
                name: "ProductBookings");

            migrationBuilder.DropTable(
                name: "RegulatorSets");

            migrationBuilder.DropTable(
                name: "Tanks");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
