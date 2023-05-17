using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeManagement.Contracts.Common.CreateBrand
{
    public record CreateBrandResponse(
        Guid Id,
        string Name,
        string Description, 
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime
    );
    public record BrandModelResponse
    (

        Guid Id,
        string Name,
        string Description
    );
}
