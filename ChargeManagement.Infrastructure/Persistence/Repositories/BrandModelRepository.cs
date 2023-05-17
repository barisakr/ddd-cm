
using ChargeManagement.Application.Common.Interfaces.Persistence;
using ChargeManagement.Domain.Brand; 
using ChargeManagement.Domain.Brand.ValueObjects;
using ChargeManagement.Domain.Menu;
using ChargeManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChargeManagement.Infrastructure.Persistence.Repositories
{
    public class BrandModelRepository : IBrandModelRepository
    {
        private readonly ChargeManagementDbContext _context;

        public BrandModelRepository(ChargeManagementDbContext context)
        {
            _context = context;
        }

        public void Add(BrandModel brandModel)
        {
            _context.Add(brandModel);
            _context.SaveChanges();
        }

        public async Task<List<BrandModel>> GetBrandModelsAsync(BrandId  brandId)
        { 
            return await _context.BrandModels.Where(x => x.BrandId == brandId).ToListAsync(); 
        }
    }
}