using AutoMapper;
using LeaveManagementServer.Application.Features.Auth.Register;
using LeaveManagementServer.Application.Features.LeaveRequests.CreateLeaveRequest;
using LeaveManagementServer.Application.Features.LeaveRequests.UpdateLeaveRequest;
using LeaveManagementServer.Application.Features.LeaveTypes.CreateLeaveType;
using LeaveManagementServer.Application.Features.Periods.CreatePeriod;
using LeaveManagementServer.Application.Features.Periods.UpdatePeriod;
using LeaveManagementServer.Domain.Entities;
using LeaveManagementServer.Domain.Enums;

namespace LeaveManagementServer.Application.Mapping;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AppUser, RegisterCommand>().ReverseMap();

        CreateMap<CreatePeriodCommand, Period>().ReverseMap();
        CreateMap<UpdatePeriodCommand, Period>().ReverseMap();

        CreateMap<CreateLeaveTypeCommand, LeaveType>().ReverseMap();
        CreateMap<CreateLeaveTypeCommand, LeaveType>().ReverseMap();

        CreateMap<CreateLeaveRequestCommand, LeaveRequest>().ForMember(member => member.LeaveRequestStatus, options =>
        {
            options.MapFrom(map => LeaveRequestStatusEnum.FromValue(map.LeaveRequestStatusValue));
        });
        CreateMap<UpdateLeaveRequestCommand, LeaveRequest>().ForMember(member => member.LeaveRequestStatus, options =>
        {
            options.MapFrom(map => LeaveRequestStatusEnum.FromValue(map.LeaveRequestStatusValue));
        });
    }
}