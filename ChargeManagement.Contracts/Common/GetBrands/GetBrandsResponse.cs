using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargeManagement.Domain.Brand;

namespace ChargeManagement.Contracts.Common.GetBrands
{ 
    public record GetBrandsResponse(
        List<Brand> data
    );

    public record GetBrandsResponseDto(
        Guid Id,
        string Name,
        string Description
    );
}
