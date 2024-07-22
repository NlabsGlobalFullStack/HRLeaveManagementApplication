using AutoMapper;
using LeaveManagementServer.Domain.Repositories;
using MediatR;
using Nlabs.GenericRepository;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.Periods.UpdatePeriod;

internal sealed class UpdatePeriodCommandHandler
    (
        IPeriodRepository periodRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdatePeriodCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdatePeriodCommand request, CancellationToken cancellationToken)
    {
        var periodIsExists = await periodRepository.FirstOrDefaultAsync(p => p.Name == request.Name, cancellationToken);
        if (periodIsExists is null)
        {
            return Result<string>.Failure("Period not found!");
        }

        var period = mapper.Map(request, periodIsExists);

        periodRepository.Update(period);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("The action successsfull");
    }
}
