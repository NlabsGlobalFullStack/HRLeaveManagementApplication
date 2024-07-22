using MediatR;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.LeaveTypes.CreateLeaveType;
public sealed record CreateLeaveTypeCommand
(
    string Name,
    int[] NumberOfDays

) : IRequest<Result<string>>;


