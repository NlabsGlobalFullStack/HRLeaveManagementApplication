using MediatR;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.Periods.UpdatePeriod;
public sealed record UpdatePeriodCommand
(
    Guid Id,
    string Name,
    DateOnly StartDate,
    DateOnly EndDate
) : IRequest<Result<string>>;
