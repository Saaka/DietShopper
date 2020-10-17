namespace DietShopper.Persistence
{
    internal class Constants
    {
        public const string AppConnectionString = nameof(AppConnectionString);

        public const string DefaultSchema = "dietshopper";
        public const string DefaultMigrationsTable = "MigrationsDietShopper";

        internal class SqlTypes
        {
            public const string Decimal = "decimal(18,2)";
        }
    }
}