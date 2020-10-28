using Microsoft.EntityFrameworkCore.Migrations;

namespace DietShopper.Persistence.Migrations
{
    public partial class AlterMeasuresRenameShortNameToSymbol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("ShortName", "Measures", "Symbol", Constants.DefaultSchema);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("Symbol", "Measures", "ShortName", Constants.DefaultSchema);
        }
    }
}
