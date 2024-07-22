using LeaveManagementServer.Domain.Dtos;
using MediatR;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.Auth.Login;
public sealed record LoginCommand(
    string UserNameOrEmail,
    string Password) : IRequest<Result<LoginCommandResponse>>;