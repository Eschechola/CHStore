using System;
using Microsoft.EntityFrameworkCore;
using CHStore.Application.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHStore.Application.Sales.Infra.Mapping
{
    public class StatusMap : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

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
