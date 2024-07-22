using LeaveManagementServer.Domain.Dtos;
using MediatR;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.LeaveRequests.GetbyIdLeaveRequest;
public sealed record GetbyIdLeaveRequestQuery(Guid Id) : IRequest<Result<LeaveRequestResponse>>;
