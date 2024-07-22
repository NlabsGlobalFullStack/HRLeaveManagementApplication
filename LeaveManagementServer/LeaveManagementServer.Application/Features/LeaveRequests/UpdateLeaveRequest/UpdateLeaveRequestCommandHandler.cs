using AutoMapper;
using LeaveManagementServer.Domain.Repositories;
using MediatR;
using Nlabs.GenericRepository;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.LeaveRequests.UpdateLeaveRequest;

internal sealed class UpdateLeaveRequestCommandHandler
    (
        ILeaveRequestRepository leaveRequestRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateLeaveRequestCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequestIsExists = await leaveRequestRepository.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (leaveRequestIsExists is null)
        {
            return Result<string>.Failure("Leave Request not found!");
        }

        var leaveRequest = mapper.Map(request, leaveRequestIsExists);

        leaveRequestRepository.Update(leaveRequest);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "The action successfull";
    }
}
