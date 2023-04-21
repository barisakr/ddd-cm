using ChargeManagement.Domain.User;
using ChargeManagement.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChargeManagement.Infrastructure.Persistence.Configutations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUserTable(builder);
        }
        private static void ConfigureUserTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    _ => UserId.CreateUnique());

            builder.Property(m => m.FirstName)
                .HasMaxLength(100);

            builder.Property(m => m.LastName)
                .HasMaxLength(100);
        }
    }
}