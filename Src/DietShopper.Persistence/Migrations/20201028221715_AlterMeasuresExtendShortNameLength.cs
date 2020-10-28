using Microsoft.EntityFrameworkCore.Migrations;

namespace DietShopper.Persistence.Migrations
{
    public partial class AlterMeasuresExtendShortNameLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                schema: "dietshopper",
                table: "Measures",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                schema: "dietshopper",
                table: "Measures",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);
        }
    }
}
