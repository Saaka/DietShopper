using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietShopper.Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => x.ProductCategoryId);

            builder.Property(x => x.ProductCategoryGuid)
                .IsRequired();

            builder.HasIndex(x => x.ProductCategoryGuid)
                .HasName("IX_ProductCategories_ProductCategoryGuid")
                .IncludeProperties(x => x.ProductCategoryId)
                .IsUnique();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(ProductCategoryValidationConstants.ProductCategoryNameMaxLength);

            builder.Property(x => x.IsActive)
                .IsRequired();
        }
    }
}