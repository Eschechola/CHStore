using Microsoft.EntityFrameworkCore;
using CHStore.Application.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CHStore.Application.Sales.Infra.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            // 1 : N => Pedido : Status
            builder.HasMany(x => x.Status)
                .WithOne(y => y.Order)
                .HasForeignKey(x => x.OrderId);

            // 1 : N => Pedido : Status
            builder.HasMany(x => x.OrderProducts)
                .WithOne(y => y.Order)
                .HasForeignKey(x => x.OrderId);

            // 1 : 1 => Pedido : Cupom
            builder.HasOne(x => x.Coupon)
                .WithOne(y => y.Order)
                .HasForeignKey<Order>(y => y.CouponId);

            // 1 : 1 => Pedido : Transportadora
            builder.HasOne(x => x.TransportCompany)
                .WithOne(y => y.Order)
                .HasForeignKey<Order>(y => y.TransportCompanyId);

            builder.Property(x => x.PaymentMethod)
                .IsRequired()
                .HasColumnType("INT")
                .HasColumnName("PaymentMethod");

            builder.Property(x => x.FreightPrice)
                .IsRequired()
                .HasColumnType("FLOAT")
                .HasColumnName("FreightPrice");

            builder.Property(x => x.TotalPrice)
                .IsRequired()
                .HasColumnType("FLOAT")
                .HasColumnName("TotalPrice");

            builder.Property(x => x.ProductsPrice)
                .IsRequired()
                .HasColumnType("FLOAT")
                .HasColumnName("ProductsPrice");

            builder.Property(x => x.RequestDate)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasColumnType("DATETIME")
                .HasColumnName("RequestDate");
        }
    }
}
