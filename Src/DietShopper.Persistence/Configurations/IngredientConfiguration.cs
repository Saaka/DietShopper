using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietShopper.Persistence.Configurations
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(x => x.IngredientId);

            builder.Property(x => x.IngredientGuid)
                .IsRequired();

            builder.HasIndex(x => x.IngredientGuid)
                .HasName("IX_Ingredients_IngredientGuid")
                .IncludeProperties(x => x.IngredientId)
                .IsUnique();

            builder.Property(x => x.Amount)
                .HasColumnType(Constants.SqlTypes.Decimal)
                .IsRequired();

            builder.Property(x => x.AmountInGrams)
                .HasColumnType(Constants.SqlTypes.Decimal)
                .IsRequired();

            builder.Property(x => x.Note)
                .IsRequired(false)
                .HasMaxLength(IngredientValidationConstants.NoteMaxLength);

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ProductMeasure)
                .WithMany()
                .HasForeignKey(x => x.ProductMeasureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}