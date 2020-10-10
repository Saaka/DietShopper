using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietShopper.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.Property(x => x.UserGuid)
                .IsRequired();

            builder.HasIndex(x => x.UserGuid)
                .HasName("IX_Users_UserGuid")
                .IncludeProperties(x => x.UserId)
                .IsUnique();

            builder.Property(x => x.DisplayName)
                .IsRequired()
                .HasMaxLength(UserValidationConstants.DisplayNameMaxLength);

            builder.Property(x => x.ImageUrl)
                .IsRequired()
                .HasMaxLength(UserValidationConstants.ImageUrlMaxLength);

            builder
                .Property(x => x.IsAdmin)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}