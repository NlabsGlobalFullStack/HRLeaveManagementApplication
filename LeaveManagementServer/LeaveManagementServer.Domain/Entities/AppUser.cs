using Microsoft.AspNetCore.Identity;

namespace LeaveManagementServer.Domain.Entities;
public sealed class AppUser : IdentityUser<Guid>
{
    public AppUser()
    {
        Id = Guid.NewGuid();
    }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string FullName => string.Join(" ", FirstName, LastName);
    public DateOnly DateOfBirth { get; set; } = default!;
    public string? RefreshToken { get; set; } = default;
    public DateTime? RefreshTokenExpires { get; set; } = default;
}
