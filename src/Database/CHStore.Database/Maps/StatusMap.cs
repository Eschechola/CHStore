using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CHStore.Database.Entities;

namespace CHStore.Database.Maps
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

            builder.Property(x => x.DateModified)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasColumnType("DATETIME")
                .HasColumnName("date_modified");

            builder.Property(x => x.OrderStatus)
                .IsRequired()
                .HasConversion<int>()
                .HasColumnType("BIGINT")
                .HasColumnName("order_status");
        }
    }
}
