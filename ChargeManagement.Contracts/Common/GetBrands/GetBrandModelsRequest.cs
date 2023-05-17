using ChargeManagement.Domain.Brand.ValueObjects;

namespace ChargeManagement.Contracts.Common.GetBrands
{
    public record GetBrandModelsRequest(
        BrandId BrandId 
    );
   
}
