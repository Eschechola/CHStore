using Microsoft.EntityFrameworkCore;
using CHStore.Application.Account.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHStore.Application.Account.Infra.Mapping
{
    class EmployeePermissionMap : IEntityTypeConfiguration<EmployeePermission>
    {
        public void Configure(EntityTypeBuilder<EmployeePermission> builder)
        {
            builder.ToTable("Employee_X_Permission");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.EmployeeId)
                .HasColumnType("BIGINT")
                .HasColumnName("fk_employee_id");

            builder.Property(x => x.PermissionId)
                .HasColumnType("BIGINT")
                .HasColumnName("fk_permission_id");
        }
    }
}
