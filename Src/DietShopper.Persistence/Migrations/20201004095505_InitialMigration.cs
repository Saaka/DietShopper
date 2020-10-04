using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DietShopper.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dietshopper");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dietshopper",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserGuid = table.Column<Guid>(nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 1024, nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserGuid",
                schema: "dietshopper",
                table: "Users",
                column: "UserGuid",
                unique: true)
                .Annotation("SqlServer:Include", new[] { "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "dietshopper");
        }
    }
}
