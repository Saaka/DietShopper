using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DietShopper.Persistence.Migrations
{
    public partial class AddRecipesAndIngredientsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                schema: "dietshopper",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeGuid = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "dietshopper",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                schema: "dietshopper",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientGuid = table.Column<Guid>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    MeasureId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountInGrams = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Note = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingredients_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalSchema: "dietshopper",
                        principalTable: "Measures",
                        principalColumn: "MeasureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingredients_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dietshopper",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "dietshopper",
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientGuid",
                schema: "dietshopper",
                table: "Ingredients",
                column: "IngredientGuid",
                unique: true)
                .Annotation("SqlServer:Include", new[] { "IngredientId" });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MeasureId",
                schema: "dietshopper",
                table: "Ingredients",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_ProductId",
                schema: "dietshopper",
                table: "Ingredients",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                schema: "dietshopper",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_OwnerId",
                schema: "dietshopper",
                table: "Recipes",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeGuid",
                schema: "dietshopper",
                table: "Recipes",
                column: "RecipeGuid",
                unique: true)
                .Annotation("SqlServer:Include", new[] { "RecipeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients",
                schema: "dietshopper");

            migrationBuilder.DropTable(
                name: "Recipes",
                schema: "dietshopper");
        }
    }
}
