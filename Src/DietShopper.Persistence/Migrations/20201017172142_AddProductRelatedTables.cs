using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DietShopper.Persistence.Migrations
{
    public partial class AddProductRelatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measures",
                schema: "dietshopper",
                columns: table => new
                {
                    MeasureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureGuid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    ShortName = table.Column<string>(maxLength: 8, nullable: false),
                    IsWeight = table.Column<bool>(nullable: false),
                    ValueInGrams = table.Column<decimal>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.MeasureId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                schema: "dietshopper",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryGuid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ProductCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "dietshopper",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductGuid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    ShortName = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProductCategoryId = table.Column<int>(nullable: false),
                    DefaultMeasureId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Measures_DefaultMeasureId",
                        column: x => x.DefaultMeasureId,
                        principalSchema: "dietshopper",
                        principalTable: "Measures",
                        principalColumn: "MeasureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalSchema: "dietshopper",
                        principalTable: "ProductCategories",
                        principalColumn: "ProductCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductMeasures",
                schema: "dietshopper",
                columns: table => new
                {
                    ProductMeasureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductMeasureGuid = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    MeasureId = table.Column<int>(nullable: false),
                    ValueInGrams = table.Column<decimal>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMeasures", x => x.ProductMeasureId);
                    table.ForeignKey(
                        name: "FK_ProductMeasures_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalSchema: "dietshopper",
                        principalTable: "Measures",
                        principalColumn: "MeasureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductMeasures_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dietshopper",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductNutrients",
                schema: "dietshopper",
                columns: table => new
                {
                    ProductNutrientsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductNutrientsGuid = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Calories = table.Column<int>(nullable: false),
                    Carbohydrates = table.Column<decimal>(nullable: false),
                    Proteins = table.Column<decimal>(nullable: false),
                    Fat = table.Column<decimal>(nullable: false),
                    SaturatedFat = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductNutrients", x => x.ProductNutrientsId);
                    table.ForeignKey(
                        name: "FK_ProductNutrients_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dietshopper",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measures_MeasureGuid",
                schema: "dietshopper",
                table: "Measures",
                column: "MeasureGuid",
                unique: true)
                .Annotation("SqlServer:Include", new[] { "MeasureId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductCategoryGuid",
                schema: "dietshopper",
                table: "ProductCategories",
                column: "ProductCategoryGuid",
                unique: true)
                .Annotation("SqlServer:Include", new[] { "ProductCategoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductMeasures_MeasureId",
                schema: "dietshopper",
                table: "ProductMeasures",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMeasures_ProductId",
                schema: "dietshopper",
                table: "ProductMeasures",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMeasures_ProductMeasureGuid",
                schema: "dietshopper",
                table: "ProductMeasures",
                column: "ProductMeasureGuid",
                unique: true)
                .Annotation("SqlServer:Include", new[] { "ProductMeasureId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductNutrients_ProductId",
                schema: "dietshopper",
                table: "ProductNutrients",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductNutrients_ProductNutrientsGuid",
                schema: "dietshopper",
                table: "ProductNutrients",
                column: "ProductNutrientsGuid",
                unique: true)
                .Annotation("SqlServer:Include", new[] { "ProductNutrientsId" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DefaultMeasureId",
                schema: "dietshopper",
                table: "Products",
                column: "DefaultMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                schema: "dietshopper",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGuid",
                schema: "dietshopper",
                table: "Products",
                column: "ProductGuid",
                unique: true)
                .Annotation("SqlServer:Include", new[] { "ProductId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductMeasures",
                schema: "dietshopper");

            migrationBuilder.DropTable(
                name: "ProductNutrients",
                schema: "dietshopper");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "dietshopper");

            migrationBuilder.DropTable(
                name: "Measures",
                schema: "dietshopper");

            migrationBuilder.DropTable(
                name: "ProductCategories",
                schema: "dietshopper");
        }
    }
}
