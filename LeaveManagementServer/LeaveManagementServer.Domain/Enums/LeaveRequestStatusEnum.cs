using Ardalis.SmartEnum;

namespace LeaveManagementServer.Domain.Enums;
public sealed class LeaveRequestStatusEnum : SmartEnum<LeaveRequestStatusEnum>
{
    public static readonly LeaveRequestStatusEnum Pending = new LeaveRequestStatusEnum("Pending", 0);
    public static readonly LeaveRequestStatusEnum Approwed = new LeaveRequestStatusEnum("Approwed", 1);
    public static readonly LeaveRequestStatusEnum Declined = new LeaveRequestStatusEnum("Declined", 2);
    public static readonly LeaveRequestStatusEnum Canceled = new LeaveRequestStatusEnum("Canceled", 3);
    public LeaveRequestStatusEnum(string name, int value) : base(name, value)
    {
    }
}
