using MediatR;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.Periods.CreatePeriod;
public sealed record CreatePeriodCommand
(
    string Name,
    DateOnly StartDate,
    DateOnly EndDate
) : IRequest<Result<string>>;
