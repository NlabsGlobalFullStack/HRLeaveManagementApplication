namespace LeaveManagementServer.Domain.Dtos;
public sealed record PeriodResponse
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public DateOnly StartDate { get; set; } = default!;
    public DateOnly EndDate { get; set; } = default!;
}