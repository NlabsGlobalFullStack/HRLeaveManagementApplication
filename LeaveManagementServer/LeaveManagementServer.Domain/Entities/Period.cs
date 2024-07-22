using LeaveManagementServer.Domain.Abstractions;

namespace LeaveManagementServer.Domain.Entities;

public sealed class Period : Entity
{
    public string Name { get; set; } = default!;
    public DateOnly StartDate { get; set; } = default!;
    public DateOnly EndDate { get; set; } = default!;
}