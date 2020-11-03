using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietShopper.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);

            builder.Property(x => x.ProductGuid)
                .IsRequired();

            builder.HasIndex(x => x.ProductGuid)
                .HasName("IX_Products_ProductGuid")
                .IncludeProperties(x => x.ProductId)
                .IsUnique();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(ProductValidationConstants.ProductNameMaxLength);

            builder.Property(x => x.ShortName)
                .IsRequired(false)
                .HasMaxLength(ProductValidationConstants.ProductShortNameMaxLength);

            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(ProductValidationConstants.ProductDescriptionMaxLength);

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.HasMany(x => x.ProductMeasures)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ProductNutrients)
                .WithOne(x => x.Product)
                .HasForeignKey<ProductNutrients>(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.DefaultMeasure)
                .WithMany()
                .HasForeignKey(x => x.DefaultMeasureId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ProductCategory)
                .WithMany()
                .HasForeignKey(x => x.ProductCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}