using Microsoft.EntityFrameworkCore;
using CHStore.Application.Account.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CHStore.Application.Core.Data.Maps;

namespace CHStore.Application.Account.Infra.Mapping
{
    public class EmployeePermissionMap : BaseMap<EmployeePermission>
    {
        public override void Configure(EntityTypeBuilder<EmployeePermission> builder)
        {
            builder.ToTable("EmployeePermissions", "chs");

            base.Configure(builder);

            builder.Property(x => x.EmployeeId)
                .HasColumnType("BIGINT")
                .HasColumnName("fk_employee_id");

            builder.Property(x => x.PermissionId)
                .HasColumnType("BIGINT")
                .HasColumnName("fk_permission_id");
        }
    }
}
