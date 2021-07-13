
using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Data.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHStore.Application.Core.Catalog.Infra.Data.Mapping
{
    public class BrandMap : BaseMap<Brand>
    {
        public override void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand", "chs");

            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(80)");

            // 1 : N => Marcas : Produtos
            builder.HasMany(c => c.Products)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandId)
                .HasConstraintName("fk_brand_id");
        }
    }
}
