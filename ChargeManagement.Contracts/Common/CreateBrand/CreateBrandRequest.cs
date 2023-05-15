using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeManagement.Contracts.Common.CreateBrand
{
        public record CreateBrandRequest(
            string Name,
            string Description,
            List<BrandModel> BrandModels
        );

        public record BrandModel
        (
            string Name,
            string Description
        );

}
