using ChargeManagement.Domain.Brand;

namespace ChargeManagement.Application.Common.Interfaces.Persistence
{
    public interface IBrandRepository
    {
        void Add(Brand brand); 
        Task<List<Brand>> GetBrandsAsync();
    }
  
}
