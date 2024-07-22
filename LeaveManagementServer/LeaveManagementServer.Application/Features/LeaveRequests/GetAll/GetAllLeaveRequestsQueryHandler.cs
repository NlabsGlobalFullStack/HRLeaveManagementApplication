using LeaveManagementServer.Domain.Dtos;
using LeaveManagementServer.Domain.Enums;
using LeaveManagementServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementServer.Application.Features.LeaveRequests.GetAll;

internal sealed class GetAllLeaveRequestsQueryHandler
    (
        ILeaveRequestRepository leaveRequestRepository
    ) : IRequestHandler<GetAllLeaveRequestsQuery, List<LeaveRequestResponse>>
{
    public async Task<List<LeaveRequestResponse>> Handle(GetAllLeaveRequestsQuery request, CancellationToken cancellationToken)
    {
        var leaveRequests = await leaveRequestRepository.GetAll().ToListAsync(cancellationToken);

        var response = leaveRequests.Select(leaveRequest => new LeaveRequestResponse
        {
            Id = leaveRequest.Id,
            StartDate = leaveRequest.StartDate,
            EndDate = leaveRequest.EndDate,
            LeaveType = new LeaveTypeResponse
            {
                Id = leaveRequest.LeaveTypeId,
                Name = leaveRequest.LeaveType!.Name,
                NumberOfDays = leaveRequest.LeaveType.NumberOfDays,
                LeaveAllocations = leaveRequest.LeaveType.LeaveAllocations!.Select(p => new LeaveAllocationResponse
                {
                    Id = p.Id,
                    LeaveType = new LeaveTypeResponse
                    {
                        Id = p.LeaveType!.Id,
                        Name = p.LeaveType.Name,
                        NumberOfDays = p.LeaveType.NumberOfDays
                    },
                    Employee = new UserResponse
                    {
                        Id = p.Employee!.Id,
                        FirstName = p.Employee.FirstName,
                        LastName = p.Employee.LastName,
                        FullName = p.Employee.FullName,
                        DateOfBirth = p.Employee.DateOfBirth,
                        PhoneNumber = p.Employee.PhoneNumber!,
                        Email = p.Employee.Email!,
                        UserName = p.Employee.UserName!
                    },
                    Period = new PeriodResponse
                    {
                        Id = p.Period!.Id,
                        Name = p.Period.Name,
                        StartDate = p.Period.StartDate,
                        EndDate = p.Period.EndDate
                    },
                    Days = p.Days
                }).ToList()
            },
            LeaveRequestStatus = LeaveRequestStatusEnum.FromValue(leaveRequest.LeaveRequestStatus.Value),
            LeaveRequestStatusValue = leaveRequest.LeaveRequestStatus.Value,
            Employee = new UserResponse
            {
                Id = leaveRequest.Employee!.Id,
                FirstName = leaveRequest.Employee.FirstName,
                LastName = leaveRequest.Employee.LastName,
                FullName = leaveRequest.Employee.FullName,
                DateOfBirth = leaveRequest.Employee.DateOfBirth,
                PhoneNumber = leaveRequest.Employee.PhoneNumber!,
                Email = leaveRequest.Employee.Email!,
                UserName = leaveRequest.Employee.UserName!
            },
            Reviewer = new UserResponse
            {
                Id = leaveRequest.Reviewer!.Id,
                FirstName = leaveRequest.Reviewer.FirstName,
                LastName = leaveRequest.Reviewer.LastName,
                FullName = leaveRequest.Reviewer.FullName,
                DateOfBirth = leaveRequest.Reviewer.DateOfBirth,
                PhoneNumber = leaveRequest.Reviewer.PhoneNumber!,
                Email = leaveRequest.Reviewer.Email!,
                UserName = leaveRequest.Reviewer.UserName!
            },
            RequestComments = leaveRequest.RequestComments
        }).ToList();

        return response;
    }
}
