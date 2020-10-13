using Microsoft.EntityFrameworkCore;
using CHStore.Application.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHStore.Application.Sales.Infra.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            // 1 : N => Usuário : Pedido
            builder.HasMany(x => x.Orders)
                .WithOne(y => y.User)
                .HasForeignKey(x => x.UserId);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(180)");
        }
    }
}
