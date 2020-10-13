using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CHStore.Application.Core.Catalog.Domain.Entities;

namespace CHStore.Application.Core.Catalog.Infra.Data.Mapping
{
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(80)");

            // 1 : N => Marcas : Produtos
            builder.HasMany(c => c.Products)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandId);
        }
    }
}
