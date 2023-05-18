using AutoMapper;
using ChargeManagement.Contracts.Common.GetBrandModels; 
using ChargeManagement.Contracts.Common.GetBrands;
using ChargeManagement.Domain.Brand;

namespace ChargeManagement.Api.Common.Mapping
{
    public class BrandModelMappingProfile : Profile
    {
        public BrandModelMappingProfile()
        {
            

            CreateMap<BrandModel, GetBrandModelsRequest>(); 
            CreateMap<GetBrandModelsResponse, GetBrandModelsRequest>();

            CreateMap<BrandModel, Brand>().ReverseMap();
        }

        
    }
 
}
