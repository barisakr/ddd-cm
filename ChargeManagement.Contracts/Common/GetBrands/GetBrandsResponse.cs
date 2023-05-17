using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeManagement.Contracts.Common.GetBrands
{
   
    public record GetBrandsResponse(
        string Name,
        string Description,
        List<Brand> Brand
    ); 
    public record Brand
    (
        string Name,
        string Description
    );
}
