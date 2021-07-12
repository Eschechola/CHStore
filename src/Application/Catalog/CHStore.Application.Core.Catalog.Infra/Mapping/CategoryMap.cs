using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Data.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHStore.Application.Core.Catalog.Infra.Data.Mapping
{
    public class CategoryMap : BaseMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category", "chs");

            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(80)");

            // 1 : N => Categorias : Produtos
            builder
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .HasConstraintName("fk_category_id");
        }
    }
}
