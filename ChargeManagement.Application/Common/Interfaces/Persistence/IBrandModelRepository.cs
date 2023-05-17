using ChargeManagement.Domain.Brand;
using ChargeManagement.Domain.Brand.ValueObjects;

namespace ChargeManagement.Application.Common.Interfaces.Persistence
{
    public interface IBrandModelRepository
    {
        void Add(BrandModel brand); 
        Task<List<BrandModel>> GetBrandModelsAsync(BrandId brandId);
    }
  
}
