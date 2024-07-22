using LeaveManagementServer.Domain.Abstractions;

namespace LeaveManagementServer.Domain.Entities;

public sealed class LeaveAllocation : Entity
{
    public Guid LeaveTypeId { get; set; }
    public LeaveType? LeaveType { get; set; }

    public Guid EmployeeId { get; set; } = default!;
    public AppUser? Employee { get; set; }

    public Guid PeriodId { get; set; } = default!;
    public Period? Period { get; set; }
    public int[] Days { get; set; } = default!;
}
