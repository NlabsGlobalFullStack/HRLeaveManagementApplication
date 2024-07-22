using MediatR;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.LeaveRequests.DeleteByIdLeaveRequest;
public sealed record DeleteByIdLeaveRequestCommand(Guid Id) : IRequest<Result<string>>;
