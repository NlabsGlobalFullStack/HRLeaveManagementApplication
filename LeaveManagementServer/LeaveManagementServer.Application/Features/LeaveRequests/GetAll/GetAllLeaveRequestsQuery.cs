using LeaveManagementServer.Domain.Dtos;
using MediatR;

namespace LeaveManagementServer.Application.Features.LeaveRequests.GetAll;
public sealed record GetAllLeaveRequestsQuery : IRequest<List<LeaveRequestResponse>>;
