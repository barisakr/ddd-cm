using ChargeManagement.Domain.Brand;
using ChargeManagement.Domain.Brand.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChargeManagement.Infrastructure.Persistence.Configutations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            ConfigureBrandsTable(builder); 
        } 
       
        private static void ConfigureBrandsTable(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");

            builder.HasKey(m => m.Id); 

            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    _ => BrandId.CreateUnique());

            builder.Property(m => m.Name)
                .HasMaxLength(100);

            builder.Property(m => m.Description)
                .HasMaxLength(100);
 
        }
    }
}