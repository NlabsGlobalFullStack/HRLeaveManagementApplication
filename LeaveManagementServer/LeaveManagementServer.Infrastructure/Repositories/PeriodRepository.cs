using LeaveManagementServer.Domain.Entities;
using LeaveManagementServer.Domain.Repositories;
using LeaveManagementServer.Infrastructure.Context;
using Nlabs.GenericRepository;

namespace LeaveManagementServer.Infrastructure.Repositories;

internal sealed class PeriodRepository : Repository<Period, ApplicationDbContext>, IPeriodRepository
{
    public PeriodRepository(ApplicationDbContext context) : base(context)
    {
    }
}
