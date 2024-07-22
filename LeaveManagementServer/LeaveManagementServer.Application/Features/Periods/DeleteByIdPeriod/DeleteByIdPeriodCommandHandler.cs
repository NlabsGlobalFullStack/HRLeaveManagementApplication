using LeaveManagementServer.Domain.Repositories;
using MediatR;
using Nlabs.GenericRepository;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.Periods.DeleteByIdPeriod;

internal sealed class DeleteByIdPeriodCommandHandler
    (
        IPeriodRepository periodRepository,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteByIdPeriodCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteByIdPeriodCommand request, CancellationToken cancellationToken)
    {
        var period = await periodRepository.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (period is null)
        {
            return Result<string>.Failure("Period not found!");
        }

        periodRepository.Delete(period);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("The action successsfull");
    }
}
