using ChargeManagement.Application.Common;
using ChargeManagement.Application.Common.Commands.CreateBrand;
using ChargeManagement.Contracts.Common.CreateBrand;
using ChargeManagement.Domain.Brand;
using Mapster;

namespace ChargeManagement.Api.Common.Mapping
{
    public class BrandMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateBrandRequest, CreateBrandCommand>();

            config.NewConfig<Brand, CreateBrandResponse>()
                .Map(dest => dest.Id, s => s.Id.Value)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description);


            config.NewConfig<Brand, GetBrandsResponse>()
                .Map(dest => dest, s => s);

            config.NewConfig<Brand, GetBrandsResponse>()
                .Map(dest => dest.Brands, src => src);
        }
    }
} 