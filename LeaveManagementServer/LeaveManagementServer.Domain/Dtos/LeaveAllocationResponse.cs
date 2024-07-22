namespace LeaveManagementServer.Domain.Dtos;
public sealed record LeaveAllocationResponse
{
    public Guid Id { get; set; } = default!;
    public LeaveTypeResponse LeaveType { get; set; } = default!;
    public UserResponse Employee { get; set; } = default!;
    public PeriodResponse Period { get; set; } = default!;
    public int[] Days { get; set; } = default!;
}
