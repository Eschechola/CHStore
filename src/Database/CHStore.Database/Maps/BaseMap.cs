using CHStore.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CHStore.Database.Maps
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T>
        where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired()
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.HasIndex(x => x.Id)
                .IsUnique();

            builder.Ignore(x => x.Errors);

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasColumnType("DATETIME");

            builder.Property(x => x.UpdatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasColumnType("DATETIME");
        }
    }
}
