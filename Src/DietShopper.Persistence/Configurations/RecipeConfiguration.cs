using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietShopper.Persistence.Configurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(x => x.RecipeId);

            builder.Property(x => x.RecipeGuid)
                .IsRequired();

            builder.HasIndex(x => x.RecipeGuid)
                .HasName("IX_Recipes_RecipeGuid")
                .IncludeProperties(x => x.RecipeId)
                .IsUnique();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(RecipeValidationConstant.RecipeNameMaxLength);

            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(RecipeValidationConstant.RecipeDescMaxLength);

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.HasMany(x => x.Ingredients)
                .WithOne(x => x.Recipe)
                .HasForeignKey(x => x.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}