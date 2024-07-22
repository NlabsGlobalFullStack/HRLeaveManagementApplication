using LeaveManagementServer.Domain.Entities;
using LeaveManagementServer.Domain.Repositories;
using LeaveManagementServer.Infrastructure.Context;
using Nlabs.GenericRepository;

namespace LeaveManagementServer.Infrastructure.Repositories;
internal sealed class LeaveAllocationRepository : Repository<LeaveAllocation, ApplicationDbContext>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(ApplicationDbContext context) : base(context)
    {
    }
}
