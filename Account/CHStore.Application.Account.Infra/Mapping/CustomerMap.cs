using Microsoft.EntityFrameworkCore;
using CHStore.Application.Account.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CHStore.Application.Account.Infra.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

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

            builder.Property(x => x.DocumentType)
                .IsRequired()
                .HasConversion<int>()
                .HasColumnName("document_type")
                .HasColumnType("BIGINT");

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("cpf")
                .HasColumnType("VARCHAR(11)");

            builder.Property(x => x.CNPJ)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("cnpj")
                .HasColumnType("VARCHAR(14)");

            builder.Property(x => x.Active)
                .IsRequired()
                .HasDefaultValue(true)
                .HasColumnName("fl_active")
                .HasColumnType("BIT");

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
