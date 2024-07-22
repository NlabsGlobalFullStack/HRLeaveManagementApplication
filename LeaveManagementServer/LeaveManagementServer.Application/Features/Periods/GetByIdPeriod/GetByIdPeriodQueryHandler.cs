using LeaveManagementServer.Domain.Dtos;
using LeaveManagementServer.Domain.Repositories;
using MediatR;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.Periods.GetByIdPeriod;

internal sealed class GetByIdPeriodQueryHandler
    (
        IPeriodRepository periodRepository
    ) : IRequestHandler<GetByIdPeriodQuery, Result<PeriodResponse>>
{
    public async Task<Result<PeriodResponse>> Handle(GetByIdPeriodQuery request, CancellationToken cancellationToken)
    {
        var period = await periodRepository.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (period is null)
        {
            return Result<PeriodResponse>.Failure("Period not found!");
        }

        var response = new PeriodResponse
        {
            Id = period.Id,
            Name = period.Name,
            StartDate = period.StartDate,
            EndDate = period.EndDate
        };

        return response;
    }
}
