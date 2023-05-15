 
using ChargeManagement.Domain.Brand;
using ChargeManagement.Domain.Brand.ValueObjects;
using ChargeManagement.Domain.Host.ValueObjects;
using ChargeManagement.Domain.Menu;
using ChargeManagement.Domain.Menu.Entities;
using ChargeManagement.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChargeManagement.Infrastructure.Persistence.Configutations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            ConfigureBrandsTable(builder);
            ConfigureBrandModelsTable(builder);  
        } 
        private static void ConfigureBrandModelsTable(EntityTypeBuilder<Brand> builder)
        {
            builder.OwnsMany(m => m.BrandModels, sbldr =>
            {
                sbldr.ToTable("BrandModels");

                sbldr.WithOwner().HasForeignKey("BrandId");

                sbldr.HasKey("Id", "BrandId");

                sbldr.Property(s => s.Id)
                    .HasColumnName("BrandModelId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => BrandModelId.Create(value));

                sbldr.Property(s => s.Name)
                    .HasMaxLength(100);

                sbldr.Property(s => s.Description)
                    .HasMaxLength(100);
                  
            });


            builder.Metadata.FindNavigation(nameof(Brand.BrandModels))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);

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