using ChargeManagement.Contracts.Common.CreateBrand;
using ChargeManagement.Domain.Brand;

namespace ChargeManagement.Contracts.Common.GetBrandModels
{
    public record GetBrandModelsResponse(
        List<BrandModel> data
    );

    public record GetBrandModelsResponseDto(
        Guid Id,
        Guid BrandId,
        string Name,
        string Description
    );
}
