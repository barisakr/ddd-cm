
using ChargeManagement.Application.Common.Interfaces.Persistence;
using ChargeManagement.Domain.Brand;
using ChargeManagement.Domain.Menu;
using ChargeManagement.Infrastructure.Persistence;

namespace ChargeManagement.Infrastructure.Persistence.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ChargeManagementDbContext _context;

        public BrandRepository(ChargeManagementDbContext context)
        {
            _context = context;
        }

        public void Add(Brand menu)
        {
            _context.Add(menu);
            _context.SaveChanges();
        }
    }
}