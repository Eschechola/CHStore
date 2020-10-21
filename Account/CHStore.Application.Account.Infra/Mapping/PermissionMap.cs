using Microsoft.EntityFrameworkCore;
using CHStore.Application.Account.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHStore.Application.Account.Infra.Mapping
{
    public class PermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            // 1 : N =>  Permissão : Permissão de funcionario
            builder.HasMany(x => x.EmployeePermissions)
                .WithOne(y => y.Permission)
                .HasForeignKey(x => x.PermissionId);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("VARCHAR(30)")
                .HasColumnName("name");
        }
    }
}
