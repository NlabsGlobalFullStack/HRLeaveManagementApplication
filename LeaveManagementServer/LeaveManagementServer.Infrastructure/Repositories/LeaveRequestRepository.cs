using LeaveManagementServer.Domain.Entities;
using LeaveManagementServer.Domain.Repositories;
using LeaveManagementServer.Infrastructure.Context;
using Nlabs.GenericRepository;

namespace LeaveManagementServer.Infrastructure.Repositories;

internal sealed class LeaveRequestRepository : Repository<LeaveRequest, ApplicationDbContext>, ILeaveRequestRepository
{
    public LeaveRequestRepository(ApplicationDbContext context) : base(context)
    {
    }
}
