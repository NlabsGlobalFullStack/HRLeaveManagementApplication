using MediatR;

namespace LeaveManagementServer.Application.Features.Users.GetAllUsers;
public sealed record GetAllUsersQuery : IRequest<List<UserResponse>>;
