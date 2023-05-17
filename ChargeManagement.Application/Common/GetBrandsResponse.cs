using ChargeManagement.Domain.Brand;

namespace ChargeManagement.Application.Common
{
    public record GetBrandsResponse(
        List<Brand> Brands
        );
   
}
