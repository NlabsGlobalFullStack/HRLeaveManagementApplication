namespace LeaveManagementServer.Domain.Dtos;
public sealed record LeaveTypeResponse
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public int[] NumberOfDays { get; set; } = default!;
    public List<LeaveAllocationResponse>? LeaveAllocations { get; set; }
}
