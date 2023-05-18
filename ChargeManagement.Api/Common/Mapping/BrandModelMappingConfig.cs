using ChargeManagement.Application.Common.Commands.CreateBrand;
using ChargeManagement.Contracts.Common.CreateBrand;
using ChargeManagement.Contracts.Common.GetBrandModels;
using ChargeManagement.Contracts.Common.GetBrands;
using ChargeManagement.Domain.Brand;
using Mapster;
using BrandModel = ChargeManagement.Domain.Brand.BrandModel;

namespace ChargeManagement.Api.Common.Mapping
{
    public class BrandModelMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        { 
            config.NewConfig<List<BrandModel>, GetBrandModelsResponse>()
                .Map(dest => dest.data, s => s.Adapt<List<BrandModel>>());
 
        }
    }
} 