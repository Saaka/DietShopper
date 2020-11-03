using DietShopper.Application.Models;
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

            builder.Property(x => x.Symbol)
                .IsRequired()
                .HasMaxLength(MeasureValidationConstants.MeasureSymbolMaxLength);

            builder.Property(x => x.IsWeight)
                .IsRequired();

            builder.Property(x => x.ValueInGrams)
                .HasColumnType(Constants.SqlTypes.Decimal)
                .IsRequired(false);

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.Property(x => x.IsBaseline)
                .IsRequired();
        }
    }
}