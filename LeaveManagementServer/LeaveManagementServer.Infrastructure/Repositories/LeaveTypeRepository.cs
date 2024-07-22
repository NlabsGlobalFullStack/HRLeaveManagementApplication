using LeaveManagementServer.Domain.Entities;
using LeaveManagementServer.Domain.Repositories;
using LeaveManagementServer.Infrastructure.Context;
using Nlabs.GenericRepository;

namespace LeaveManagementServer.Infrastructure.Repositories;

internal sealed class LeaveTypeRepository : Repository<LeaveType, ApplicationDbContext>, ILeaveTypeRepository
{
    public LeaveTypeRepository(ApplicationDbContext context) : base(context)
    {
    }
}
