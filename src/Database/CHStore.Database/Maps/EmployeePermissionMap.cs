using CHStore.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHStore.Database.Maps
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
