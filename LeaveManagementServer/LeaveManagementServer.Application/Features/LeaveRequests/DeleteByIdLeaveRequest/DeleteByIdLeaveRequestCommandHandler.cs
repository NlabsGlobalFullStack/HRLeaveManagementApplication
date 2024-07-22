using LeaveManagementServer.Domain.Repositories;
using MediatR;
using Nlabs.GenericRepository;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.LeaveRequests.DeleteByIdLeaveRequest;

internal sealed class DeleteByIdLeaveRequestCommandHandler
    (
        ILeaveRequestRepository leaveRequestRepository,
        IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteByIdLeaveRequestCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteByIdLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await leaveRequestRepository.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (leaveRequest is null)
        {
            return Result<string>.Failure("Leave Request not found!");
        }

        leaveRequestRepository.Delete(leaveRequest);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("The action successfull");
    }
}
