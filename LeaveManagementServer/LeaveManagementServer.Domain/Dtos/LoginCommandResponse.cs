namespace LeaveManagementServer.Domain.Dtos;
public sealed record LoginCommandResponse(
    string Token,
    string RefreshToken,
    DateTime RefreshTokenExpires);