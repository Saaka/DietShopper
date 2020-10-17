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
                .IsRequired();

            builder.Property(x => x.Proteins)
                .IsRequired();

            builder.Property(x => x.Fat)
                .IsRequired();

            builder.Property(x => x.SaturatedFat)
                .IsRequired();
        }
    }
}