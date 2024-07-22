using LeaveManagementServer.Domain.Enums;

namespace LeaveManagementServer.Domain.Dtos;

public sealed record LeaveRequestResponse
{
    public Guid Id { get; set; } = default!;
    public DateTime StartDate { get; set; } = default!;
    public DateTime EndDate { get; set; } = default!;
    public LeaveTypeResponse LeaveType { get; set; } = default!;
    public LeaveRequestStatusEnum LeaveRequestStatus { get; set; } = default!;
    public int LeaveRequestStatusValue { get; set; } = default!;
    public UserResponse Employee { get; set; } = default!;
    public UserResponse Reviewer { get; set; } = default!;
    public string? RequestComments { get; set; } = default;
}
