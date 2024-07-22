using MediatR;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.Periods.DeleteByIdPeriod;
public sealed record DeleteByIdPeriodCommand(Guid Id) : IRequest<Result<string>>;
