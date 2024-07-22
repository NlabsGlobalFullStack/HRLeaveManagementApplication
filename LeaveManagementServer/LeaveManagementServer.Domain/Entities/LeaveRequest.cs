using LeaveManagementServer.Domain.Abstractions;
using LeaveManagementServer.Domain.Enums;

namespace LeaveManagementServer.Domain.Entities;
public sealed class LeaveRequest : Entity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid LeaveTypeId { get; set; } = default!;
    public LeaveType? LeaveType { get; set; }
    public LeaveRequestStatusEnum LeaveRequestStatus { get; set; } = LeaveRequestStatusEnum.Pending;
    public Guid EmployeeId { get; set; } = default!;
    public AppUser? Employee { get; set; }
    public Guid? ReviewerId { get; set; } = default;
    public AppUser? Reviewer { get; set; }
    public string? RequestComments { get; set; } = default;
}
