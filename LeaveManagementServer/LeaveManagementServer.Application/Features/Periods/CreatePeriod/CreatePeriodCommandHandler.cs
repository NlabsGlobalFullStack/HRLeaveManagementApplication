using AutoMapper;
using LeaveManagementServer.Domain.Entities;
using LeaveManagementServer.Domain.Repositories;
using MediatR;
using Nlabs.GenericRepository;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.Periods.CreatePeriod;
internal sealed class CreatePeriodCommandHandler
    (
        IPeriodRepository periodRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<CreatePeriodCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreatePeriodCommand request, CancellationToken cancellationToken)
    {
        var periodIsExists = await periodRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
        if (periodIsExists)
        {
            return Result<string>.Failure("Period already exists!");
        }

        var period = mapper.Map<Period>(request);

        await periodRepository.AddAsync(period, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("The action successsfull");
    }
}
