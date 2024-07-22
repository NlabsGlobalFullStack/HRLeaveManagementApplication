using LeaveManagementServer.Domain.Entities;
using LeaveManagementServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementServer.Infrastructure.Configurations;

internal sealed class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
{
    public void Configure(EntityTypeBuilder<LeaveRequest> builder)
    {
        builder.Property(p => p.RequestComments).HasColumnType("nvarchar(500)");
        builder.Property(p => p.Createdby).HasColumnType("varchar(60)");
        builder.Property(p => p.UpdatedBy).HasColumnType("varchar(60)");

        builder.Property(p => p.LeaveRequestStatus)
            .HasConversion(p => p.Value, v => LeaveRequestStatusEnum.FromValue(v));
    }
}
