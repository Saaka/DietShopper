using Microsoft.EntityFrameworkCore.Migrations;

namespace DietShopper.Persistence.Migrations
{
    public partial class InsertIntoMeasuresInitialValues : Migration
    {
        protected override void Up(MigrationBuilder builder)
        {
            var schema = Constants.DefaultSchema;

            builder.Sql($"exec('INSERT INTO {schema}.Measures ([MeasureGuid], [Name], [Symbol], [IsWeight], [ValueInGrams], [IsActive], [IsBaseline]) VALUES " +
                        $"(NEWID(), ''Gram'', ''g'', 1, 1, 1, 1)," +
                        $"(NEWID(), ''Kilogram'', ''kg'', 1, 1000, 1, 0)," +
                        $"(NEWID(), ''Dekagram'', ''dag'', 1, 100, 1, 0)," +
                        $"(NEWID(), ''Sztuka'', ''szt.'', 0, NULL, 1, 0)," +
                        $"(NEWID(), ''Litr'', ''L'', 0, NULL, 1, 0)," +
                        $"(NEWID(), ''Szklanka'', ''szklanka'', 0, NULL, 1, 0)," +
                        $"(NEWID(), ''Łyżeczka'', ''łyżeczka'', 0, NULL, 1, 0)," +
                        $"(NEWID(), ''Łyżka'', ''łyżka'', 0, NULL, 1, 0)," +
                        $"(NEWID(), ''Plasterek'', ''plasterek'', 0, NULL, 1, 0)" +
                        $"')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var schema = Constants.DefaultSchema;
            migrationBuilder.Sql($"exec('DELETE FROM {schema}.Measures')");
        }
    }
}