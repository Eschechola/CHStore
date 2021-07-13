using Microsoft.EntityFrameworkCore;
using CHStore.Application.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CHStore.Application.Core.Data.Maps;

namespace CHStore.Application.Sales.Infra.Mapping
{
    public class StatusMap : BaseMap<Status>
    {
        public override void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status", "chs");

            base.Configure(builder);

            builder.Property(x => x.OrderId)
               .HasColumnType("BIGINT")
               .HasColumnName("fk_order_id");

            builder.Property(x => x.OrderStatus)
                .IsRequired()
                .HasConversion<int>()
                .HasColumnType("BIGINT")
                .HasColumnName("order_status");
        }
    }
}
