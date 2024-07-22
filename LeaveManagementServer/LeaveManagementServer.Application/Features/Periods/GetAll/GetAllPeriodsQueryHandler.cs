using LeaveManagementServer.Domain.Dtos;
using LeaveManagementServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementServer.Application.Features.Periods.GetAll;
internal sealed class GetAllPeriodsQueryHandler
    (
        IPeriodRepository periodRepository
    ) : IRequestHandler<GetAllPeriodsQuery, List<PeriodResponse>>
{
    public async Task<List<PeriodResponse>> Handle(GetAllPeriodsQuery request, CancellationToken cancellationToken)
    {
        var periods = await periodRepository.GetAll().ToListAsync(cancellationToken);

        var response = periods.Select(s => new PeriodResponse
        {
            Id = s.Id,
            Name = s.Name,
            StartDate = s.StartDate,
            EndDate = s.EndDate
        }).ToList();

        return response;
    }
}
