﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CHStore.Database.Entities;

namespace CHStore.Database.Maps
{
    public class PermissionMap : BaseMap<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission", "chs");

            base.Configure(builder);

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
