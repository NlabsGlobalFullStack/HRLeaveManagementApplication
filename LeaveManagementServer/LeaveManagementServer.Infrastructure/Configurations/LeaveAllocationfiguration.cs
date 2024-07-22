using LeaveManagementServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementServer.Infrastructure.Configurations;

internal sealed class LeaveAllocationfiguration : IEntityTypeConfiguration<LeaveAllocation>
{
    public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
    {
        builder.Property(p => p.Createdby).HasColumnType("varchar(60)");
        builder.Property(p => p.UpdatedBy).HasColumnType("varchar(60)");
    }
}
