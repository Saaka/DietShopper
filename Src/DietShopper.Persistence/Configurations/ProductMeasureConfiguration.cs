using DietShopper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietShopper.Persistence.Configurations
{
    public class ProductMeasureConfiguration : IEntityTypeConfiguration<ProductMeasure>
    {
        public void Configure(EntityTypeBuilder<ProductMeasure> builder)
        {
            builder.HasKey(x => x.ProductMeasureId);

            builder.Property(x => x.ProductMeasureGuid)
                .IsRequired();

            builder.HasIndex(x => x.ProductMeasureGuid)
                .HasName("IX_ProductMeasures_ProductMeasureGuid")
                .IncludeProperties(x => x.ProductMeasureId)
                .IsUnique();

            builder.Property(x => x.ValueInGrams)
                .HasColumnType(Constants.SqlTypes.Decimal)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.HasOne(x => x.Measure)
                .WithMany()
                .HasForeignKey(x => x.MeasureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}