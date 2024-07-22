using LeaveManagementServer.Domain.Dtos;
using MediatR;

namespace LeaveManagementServer.Application.Features.Periods.GetAll;
public sealed record GetAllPeriodsQuery : IRequest<List<PeriodResponse>>;
