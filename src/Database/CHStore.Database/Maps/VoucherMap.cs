using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using CHStore.Database.Entities;

namespace CHStore.Database.Maps
{
    public class VoucherMap : BaseMap<Voucher>
    {
        public override void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.ToTable("Voucher", "chs");

            base.Configure(builder);

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
