using Microsoft.EntityFrameworkCore;
using CHStore.Application.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CHStore.Application.Core.Data.Maps;

namespace CHStore.Application.Sales.Infra.Mapping
{
    public class CustomerMap : BaseMap<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "chs");

            base.Configure(builder);
            
            // 1 : N => Cliente : Pedido
            builder.HasMany(x => x.Orders)
                .WithOne(y => y.Customer)
                .HasForeignKey(x => x.CustomerId)
                .HasConstraintName("fk_customer_id");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(180)");
        }
    }
}
