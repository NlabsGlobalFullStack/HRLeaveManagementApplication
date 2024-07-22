using LeaveManagementServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementServer.Infrastructure.Configurations;
internal sealed class PeriodConfiguration : IEntityTypeConfiguration<Period>
{
    public void Configure(EntityTypeBuilder<Period> builder)
    {
        builder.Property(p => p.Name).HasColumnType("varchar(50)");
        builder.Property(p => p.Createdby).HasColumnType("varchar(60)");
        builder.Property(p => p.UpdatedBy).HasColumnType("varchar(60)");
    }
}