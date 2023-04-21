using ChargeManagement.Domain.Menu;

namespace ChargeManagement.Application.Common.Interfaces.Persistence
{
    public interface IMenuRepository
    {
        void Add(Menu menu);
    }
}