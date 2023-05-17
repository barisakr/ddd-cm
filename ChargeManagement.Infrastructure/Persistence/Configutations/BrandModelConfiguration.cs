using ChargeManagement.Domain.Brand;
using ChargeManagement.Domain.Brand.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChargeManagement.Infrastructure.Persistence.Configutations
{
    public class BrandModelConfiguration : IEntityTypeConfiguration<BrandModel>
    {
        public void Configure(EntityTypeBuilder<BrandModel> builder)
        {
            ConfigureBrandModelsTable(builder); 
        } 
       
        private static void ConfigureBrandModelsTable(EntityTypeBuilder<BrandModel> builder)
        {
            builder.ToTable("BrandModels");

            builder.HasKey(m => m.Id); 

            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    _ => BrandModelId.CreateUnique()); 
            builder.Property(m => m.Name)
                .HasMaxLength(100);

            builder.Property(m => m.Description)
                .HasMaxLength(100);

            builder.Property(m => m.BrandId)
                .HasConversion(
                    id => id.Value,
                    value => BrandId.Create(value));

        }
    }
}