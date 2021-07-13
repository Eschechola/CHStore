using Microsoft.EntityFrameworkCore;
using CHStore.Application.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CHStore.Application.Core.Data.Maps;

namespace CHStore.Application.Sales.Infra.Mapping
{
    public class ProductMap : BaseMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", "chs");

            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(300)");

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnName("price")
                .HasColumnType("FLOAT");
        }
    }
}
