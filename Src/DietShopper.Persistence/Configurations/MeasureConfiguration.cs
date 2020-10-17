using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietShopper.Persistence.Configurations
{
    public class MeasureConfiguration : IEntityTypeConfiguration<Measure>
    {
        public void Configure(EntityTypeBuilder<Measure> builder)
        {
            builder.HasKey(x => x.MeasureId);

            builder.Property(x => x.MeasureGuid)
                .IsRequired();

            builder.HasIndex(x => x.MeasureGuid)
                .HasName("IX_Measures_MeasureGuid")
                .IncludeProperties(x => x.MeasureId)
                .IsUnique();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(MeasureValidationConstants.MeasureNameMaxLength);

            builder.Property(x => x.ShortName)
                .IsRequired()
                .HasMaxLength(MeasureValidationConstants.MeasureShortNameMaxLength);

            builder.Property(x => x.IsWeight)
                .IsRequired();

            builder.Property(x => x.ValueInGrams)
                .HasColumnType(Constants.SqlTypes.Decimal)
                .IsRequired(false);

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.HasMany(x => x.DefaultProducts)
                .WithOne(x => x.DefaultMeasure)
                .HasForeignKey(x => x.DefaultMeasureId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ProductMeasures)
                .WithOne(x => x.Measure)
                .HasForeignKey(x => x.MeasureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}