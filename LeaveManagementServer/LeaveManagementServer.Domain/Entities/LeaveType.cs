using LeaveManagementServer.Domain.Abstractions;

namespace LeaveManagementServer.Domain.Entities;

public sealed class LeaveType : Entity
{
    public string Name { get; set; } = default!;
    public int[] NumberOfDays { get; set; } = default!;
    public List<LeaveAllocation>? LeaveAllocations { get; set; }
}
