﻿// <auto-generated />
using System;
using CHStore.Application.Core.Catalog.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CHStore.Application.Core.Catalog.Infra.Data.Migrations
{
    [DbContext(typeof(CatalogContext))]
    partial class CatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CHStore.Application.Core.Catalog.Domain.Entities.Brand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("biglong")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(80)")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("CHStore.Application.Core.Catalog.Domain.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("biglong")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(80)")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("CHStore.Application.Core.Catalog.Domain.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("biglong")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("fl_active")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<long>("BrandId")
                        .HasColumnType("biglong");

                    b.Property<long>("CategoryId")
                        .HasColumnType("biglong");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(300)")
                        .HasMaxLength(300);

                    b.Property<double>("Price")
                        .HasColumnName("price")
                        .HasColumnType("FLOAT");

                    b.Property<DateTime>("RegisterDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("register_date")
                        .HasColumnType("DATETIME")
                        .HasDefaultValue(new DateTime(2020, 10, 7, 18, 27, 23, 70, DateTimeKind.Local).AddTicks(1397));

                    b.Property<long>("Size")
                        .HasColumnName("size")
                        .HasColumnType("long");

                    b.Property<long>("Stock")
                        .HasColumnName("stock")
                        .HasColumnType("long");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnName("url_image")
                        .HasColumnType("VARCHAR(MAX)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("CHStore.Application.Core.Catalog.Domain.Entities.Product", b =>
                {
                    b.HasOne("CHStore.Application.Core.Catalog.Domain.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CHStore.Application.Core.Catalog.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
