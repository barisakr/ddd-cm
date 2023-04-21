using ChargeManagement.Application.Common.Interfaces.Persistence;
using ChargeManagement.Domain.Menu;

namespace ChargeManagement.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly ChargeManagementDbContext _context;

    public MenuRepository(ChargeManagementDbContext context)
    {
        _context = context;
    }

    public void Add(Menu menu)
    {
        _context.Add(menu);
        _context.SaveChanges();
    }
}