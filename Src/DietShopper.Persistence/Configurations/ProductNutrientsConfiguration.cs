using DietShopper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietShopper.Persistence.Configurations
{
    public class ProductNutrientsConfiguration : IEntityTypeConfiguration<ProductNutrients>
    {
        public void Configure(EntityTypeBuilder<ProductNutrients> builder)
        {
            builder.HasKey(x => x.ProductNutrientsId);

            builder.Property(x => x.ProductNutrientsGuid)
                .IsRequired();

            builder.HasIndex(x => x.ProductNutrientsGuid)
                .HasName("IX_ProductNutrients_ProductNutrientsGuid")
                .IncludeProperties(x => x.ProductNutrientsId)
                .IsUnique();

            builder.Property(x => x.Calories)
                .IsRequired();

            builder.Property(x => x.Carbohydrates)
                .HasColumnType(Constants.SqlTypes.Decimal)
                .IsRequired();

            builder.Property(x => x.Proteins)
                .HasColumnType(Constants.SqlTypes.Decimal)
                .IsRequired();

            builder.Property(x => x.Fat)
                .HasColumnType(Constants.SqlTypes.Decimal)
                .IsRequired();

            builder.Property(x => x.SaturatedFat)
                .HasColumnType(Constants.SqlTypes.Decimal)
                .IsRequired();
        }
    }
}