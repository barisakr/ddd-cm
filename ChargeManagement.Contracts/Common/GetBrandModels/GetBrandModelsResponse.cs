using ChargeManagement.Contracts.Common.CreateBrand;
using ChargeManagement.Domain.Brand;

namespace ChargeManagement.Contracts.Common.GetBrandModels
{
    public record GetBrandModelsResponse(
        List<BrandModel> data
    ); 
    public record GetBrandModelsResponseDto(
        List<BrandModelsDto> data
    );

    public record BrandModelsDto(
        Guid brandId,
        string name,
        string description
    );



}
