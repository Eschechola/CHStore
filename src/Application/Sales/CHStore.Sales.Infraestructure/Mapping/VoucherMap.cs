using Microsoft.EntityFrameworkCore;
using CHStore.Application.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CHStore.Application.Sales.Infra.Mapping
{
    public class VoucherMap : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.ToTable("Voucher");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.Active)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnType("BIT")
                .HasColumnName("fl_active");

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("code");

            builder.Property(x => x.DiscountPercentage)
                .IsRequired()
                .HasColumnType("FLOAT")
                .HasColumnName("discount_percentage");

            builder.Property(x => x.InitialDate)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasColumnType("DATETIME")
                .HasColumnName("initial_date");

            builder.Property(x => x.FinalDate)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasColumnType("DATETIME")
                .HasColumnName("final_date");
        }
    }
}
