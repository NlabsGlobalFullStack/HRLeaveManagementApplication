using LeaveManagementServer.Domain.Dtos;
using MediatR;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.Periods.GetByIdPeriod;
public sealed record GetByIdPeriodQuery(Guid Id) : IRequest<Result<PeriodResponse>>;
