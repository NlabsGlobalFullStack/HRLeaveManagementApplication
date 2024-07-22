using MediatR;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.LeaveRequests.CreateLeaveRequest;
public sealed record CreateLeaveRequestCommand
(
    DateTime StartDate,
    DateTime EndDate,
    Guid LeaveTypeId,
    int LeaveRequestStatusValue,
    Guid EmployeeId,
    Guid? ReviewerId,
    string? RequestComments
) : IRequest<Result<string>>;
