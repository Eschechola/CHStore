using Microsoft.EntityFrameworkCore;
using CHStore.Application.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CHStore.Application.Sales.Infra.Mapping
{
    public class CouponMap : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.ToTable("Coupon");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Active)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnType("BIT")
                .HasColumnName("FL_Active");

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("code");

            builder.Property(x => x.DiscountPercentage)
                .IsRequired()
                .HasColumnType("FLOAT")
                .HasColumnName("DiscountPercentage");

            builder.Property(x => x.InitialDate)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasColumnType("DATETIME")
                .HasColumnName("InitialDate");

            builder.Property(x => x.FinalDate)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasColumnType("DATETIME")
                .HasColumnName("FinalDate");
        }
    }
}
