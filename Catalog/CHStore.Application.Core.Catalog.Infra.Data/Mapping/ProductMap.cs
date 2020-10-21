﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CHStore.Application.Core.Catalog.Domain.Entities;

namespace CHStore.Application.Core.Catalog.Infra.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.BrandId)
               .HasColumnType("BIGINT")
               .HasColumnName("fk_brand_id");

            builder.Property(x => x.CategoryId)
               .HasColumnType("BIGINT")
               .HasColumnName("fk_category_id");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(300)");

            builder.Property(x => x.Active)        
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName("fl_active")
                .HasColumnType("BIT");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("description")
                .HasColumnType("VARCHAR(MAX)");

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnName("price")
                .HasColumnType("FLOAT");

            builder.Property(x => x.RegisterDate)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasColumnType("DATETIME")
                .HasColumnName("register_date");

            builder.Property(x => x.Size)
                .IsRequired()
                .HasColumnType("long")
                .HasColumnName("size");

            builder.Property(x => x.Stock)
                .IsRequired()
                .HasColumnType("long")
                .HasColumnName("stock");

            builder.Property(x => x.UrlImage)
                .IsRequired()
                .HasColumnType("VARCHAR(MAX)")
                .HasColumnName("url_image");
        }
    }
}
