using AutoMapper;
using LeaveManagementServer.Domain.Entities;
using LeaveManagementServer.Domain.Repositories;
using MediatR;
using Nlabs.GenericRepository;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.LeaveRequests.CreateLeaveRequest;

internal sealed class CreateLeaveRequestCommandHandler
    (
        ILeaveRequestRepository leaveRequestRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateLeaveRequestCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = mapper.Map<LeaveRequest>(request);

        await leaveRequestRepository.AddAsync(leaveRequest, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The action successfull";
    }
}
