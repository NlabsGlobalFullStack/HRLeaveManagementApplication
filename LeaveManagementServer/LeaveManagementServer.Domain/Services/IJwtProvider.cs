using LeaveManagementServer.Domain.Dtos;
using LeaveManagementServer.Domain.Entities;

namespace LeaveManagementServer.Domain.Services;
public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateToken(AppUser user);
}