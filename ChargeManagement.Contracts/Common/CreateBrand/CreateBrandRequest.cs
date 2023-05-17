using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargeManagement.Domain.Brand;

namespace ChargeManagement.Contracts.Common.CreateBrand
{
        public record CreateBrandRequest(
            string Name,
            string Description,
            List<BrandModel> BrandModels
        );

      

}
