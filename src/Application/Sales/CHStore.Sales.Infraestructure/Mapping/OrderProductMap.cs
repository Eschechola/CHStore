using CHStore.Application.Core.Data.Maps;
using CHStore.Application.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHStore.Application.Sales.Infra.Mapping
{
    public class OrderProductMap : BaseMap<OrderProduct>
    {
        public override void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProduct", "chs");

            base.Configure(builder);

            builder.Property(x => x.OrderId)
                .IsRequired()
                .HasColumnType("BIGINT")
                .HasColumnName("fk_order_id");

            builder.Property(x => x.ProductId)
                .IsRequired()
                .HasColumnType("BIGINT")
                .HasColumnName("fk_product_id");

            builder.Property(x => x.Mount)
                .IsRequired()
                .HasDefaultValue(1)
                .HasColumnType("BIGINT")
                .HasColumnName("mount");

            builder.HasOne(x => x.Product)
                .WithMany(x => x.OrderProducts)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderProducts)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
