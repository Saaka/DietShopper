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

        internal class CacheKeys
        {
            public const string ProductCategoryIdCacheKey = "_pc_guid_id__";
            public const string BaselineMeasureIdCacheKey = "_m_baseline_id_";
            public const string MeasureIdCacheKey = "_m_guid_id__";
        }
    }
}