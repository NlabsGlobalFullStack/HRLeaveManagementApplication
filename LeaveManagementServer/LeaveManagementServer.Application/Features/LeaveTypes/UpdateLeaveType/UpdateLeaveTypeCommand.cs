using MediatR;
using Nlabs.Result;

namespace LeaveManagementServer.Application.Features.LeaveTypes.UpdateLeaveType;
public sealed record UpdateLeaveTypeCommand
(
    string Name,
    int[] NumberOfDays

) : IRequest<Result<string>>;

internal sealed class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Result<string>>
{
    public Task<Result<string>> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
