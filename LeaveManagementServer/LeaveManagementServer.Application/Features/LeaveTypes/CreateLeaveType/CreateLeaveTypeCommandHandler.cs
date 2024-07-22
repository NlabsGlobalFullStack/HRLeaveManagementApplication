using AutoMapper;
using LeaveManagementServer.Domain.Entities;
using LeaveManagementServer.Domain.Repositories;
using MediatR;
using Nlabs.GenericRepository;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.LeaveTypes.CreateLeaveType;

internal sealed class CreateLeaveTypeCommandHandler
    (
        ILeaveTypeRepository leaveTypeRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateLeaveTypeCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveIsExists = await leaveTypeRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
        if (leaveIsExists)
        {
            return Result<string>.Failure("Leave Type allready exist");
        }
        var leaveType = mapper.Map<LeaveType>(request);

        await leaveTypeRepository.AddAsync(leaveType, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The action successfull";
    }
}


