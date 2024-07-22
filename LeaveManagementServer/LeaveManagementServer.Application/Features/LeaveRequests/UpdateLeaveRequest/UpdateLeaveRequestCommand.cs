using MediatR;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.LeaveRequests.UpdateLeaveRequest;
public sealed record UpdateLeaveRequestCommand
(
    Guid Id,
    DateTime StartDate,
    DateTime EndDate,
    Guid LeaveTypeId,
    int LeaveRequestStatusValue,
    Guid EmployeeId,
    Guid? ReviewerId,
    string? RequestComments
) : IRequest<Result<string>>;
