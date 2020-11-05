using Microsoft.EntityFrameworkCore;
using CHStore.Application.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHStore.Application.Sales.Infra.Mapping
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
