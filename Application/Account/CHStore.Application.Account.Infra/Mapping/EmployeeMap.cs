using Microsoft.EntityFrameworkCore;
using CHStore.Application.Account.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CHStore.Application.Account.Infra.Mapping
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            // 1 : N => Permissão de funcionario : Permissão
            builder.HasMany(x => x.EmployeePermissions)
                .WithOne(y => y.Employee)
                .HasForeignKey(x => x.EmployeeId)
                .HasConstraintName("fk_employee_id");

            builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("username")
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(300)");

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("password")
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.RegisterDate)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasColumnName("register_date")
                .HasColumnType("DATETIME");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(200)");

            builder.OwnsOne(x => x.Address,
                ad =>
                {
                    ad.Property(a => a.Street)
                        .IsRequired()
                        .HasColumnType("VARCHAR(300)")
                        .HasColumnName("street");

                    ad.Property(a => a.ZipCode)
                        .IsRequired()
                        .HasColumnType("VARCHAR(16)")
                        .HasColumnName("zip_code");

                    ad.Property(a => a.Number)
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)")
                        .HasColumnName("number");

                    ad.Property(a => a.Complement)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("complement");

                    ad.Property(a => a.OpeningTime)
                        .HasColumnType("TIME")
                        .HasColumnName("opening_time");

                    ad.Property(a => a.ClosingTime)
                        .HasColumnType("TIME")
                        .HasColumnName("closing_time");
                }
            );
        }
    }
}
