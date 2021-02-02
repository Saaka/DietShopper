using Microsoft.EntityFrameworkCore.Migrations;

namespace DietShopper.Persistence.Migrations
{
    public partial class AlterIngredientsAddProductMeasureRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Measures_MeasureId",
                schema: "dietshopper",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_MeasureId",
                schema: "dietshopper",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MeasureId",
                schema: "dietshopper",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "ProductMeasureId",
                schema: "dietshopper",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_ProductMeasureId",
                schema: "dietshopper",
                table: "Ingredients",
                column: "ProductMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_ProductMeasures_ProductMeasureId",
                schema: "dietshopper",
                table: "Ingredients",
                column: "ProductMeasureId",
                principalSchema: "dietshopper",
                principalTable: "ProductMeasures",
                principalColumn: "ProductMeasureId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_ProductMeasures_ProductMeasureId",
                schema: "dietshopper",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_ProductMeasureId",
                schema: "dietshopper",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "ProductMeasureId",
                schema: "dietshopper",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "MeasureId",
                schema: "dietshopper",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MeasureId",
                schema: "dietshopper",
                table: "Ingredients",
                column: "MeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Measures_MeasureId",
                schema: "dietshopper",
                table: "Ingredients",
                column: "MeasureId",
                principalSchema: "dietshopper",
                principalTable: "Measures",
                principalColumn: "MeasureId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
