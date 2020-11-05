﻿// <auto-generated />
using System;
using CHStore.Application.Sales.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CHStore.Application.Sales.Infra.Migrations
{
    [DbContext(typeof(SalesContext))]
    partial class SalesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CHStore.Application.Sales.Domain.Entities.Voucher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("fl_active")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<double>("DiscountPercentage")
                        .HasColumnName("discount_percentage")
                        .HasColumnType("FLOAT");

                    b.Property<DateTime>("FinalDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("final_date")
                        .HasColumnType("DATETIME")
                        .HasDefaultValue(new DateTime(2020, 10, 21, 18, 26, 10, 185, DateTimeKind.Local).AddTicks(6847));

                    b.Property<DateTime>("InitialDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("initial_date")
                        .HasColumnType("DATETIME")
                        .HasDefaultValue(new DateTime(2020, 10, 21, 18, 26, 10, 184, DateTimeKind.Local).AddTicks(5876));

                    b.HasKey("Id");

                    b.ToTable("Voucher");
                });

            modelBuilder.Entity("CHStore.Application.Sales.Domain.Entities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CHStore.Application.Sales.Domain.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("VoucherId")
                        .HasColumnName("fk_coupon_id")
                        .HasColumnType("BIGINT");

                    b.Property<long>("CustomerId")
                        .HasColumnName("fk_customer_id")
                        .HasColumnType("BIGINT");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("FreightPrice")
                        .HasColumnName("freight_price")
                        .HasColumnType("FLOAT");

                    b.Property<long>("PaymentMethod")
                        .HasColumnName("payment_method")
                        .HasColumnType("BIGINT");

                    b.Property<double>("ProductsPrice")
                        .HasColumnName("products_price")
                        .HasColumnType("FLOAT");

                    b.Property<DateTime>("RequestDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("request_date")
                        .HasColumnType("DATETIME")
                        .HasDefaultValue(new DateTime(2020, 10, 21, 18, 26, 10, 194, DateTimeKind.Local).AddTicks(4927));

                    b.Property<double>("TotalPrice")
                        .HasColumnName("total_price")
                        .HasColumnType("FLOAT");

                    b.Property<long>("TransportCompanyId")
                        .HasColumnName("fk_transport_company_id")
                        .HasColumnType("BIGINT");

                    b.HasKey("Id");

                    b.HasIndex("VoucherId")
                        .IsUnique();

                    b.HasIndex("CustomerId");

                    b.HasIndex("TransportCompanyId")
                        .IsUnique();

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CHStore.Application.Sales.Domain.Entities.OrderProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Mount")
                        .HasColumnType("int");

                    b.Property<long>("OrderId")
                        .HasColumnType("BIGINT");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("CHStore.Application.Sales.Domain.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("CHStore.Application.Sales.Domain.Entities.Status", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("date_modified")
                        .HasColumnType("DATETIME")
                        .HasDefaultValue(new DateTime(2020, 10, 21, 18, 26, 10, 195, DateTimeKind.Local).AddTicks(3335));

                    b.Property<long>("OrderId")
                        .HasColumnName("fk_order_id")
                        .HasColumnType("BIGINT");

                    b.Property<long>("OrderStatus")
                        .HasColumnName("order_status")
                        .HasColumnType("BIGINT");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("CHStore.Application.Sales.Domain.Entities.TransportCompany", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("fl_active")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<string>("ApiUrl")
                        .IsRequired()
                        .HasColumnName("api_url")
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnName("cnpj")
                        .HasColumnType("VARCHAR(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("SiteUrl")
                        .IsRequired()
                        .HasColumnName("site_url")
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("TrackingUrl")
                        .IsRequired()
                        .HasColumnName("tracking_url")
                        .HasColumnType("VARCHAR(500)");

                    b.HasKey("Id");

                    b.ToTable("TransportCompany");
                });

            modelBuilder.Entity("CHStore.Application.Sales.Domain.Entities.Order", b =>
                {
                    b.HasOne("CHStore.Application.Sales.Domain.Entities.Voucher", "Voucher")
                        .WithOne("Order")
                        .HasForeignKey("CHStore.Application.Sales.Domain.Entities.Order", "VoucherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CHStore.Application.Sales.Domain.Entities.Customer", "User")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CHStore.Application.Sales.Domain.Entities.TransportCompany", "TransportCompany")
                        .WithOne("Order")
                        .HasForeignKey("CHStore.Application.Sales.Domain.Entities.Order", "TransportCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CHStore.Application.Sales.Domain.Entities.OrderProduct", b =>
                {
                    b.HasOne("CHStore.Application.Sales.Domain.Entities.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CHStore.Application.Sales.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CHStore.Application.Sales.Domain.Entities.Status", b =>
                {
                    b.HasOne("CHStore.Application.Sales.Domain.Entities.Order", "Order")
                        .WithMany("Status")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CHStore.Application.Sales.Domain.Entities.TransportCompany", b =>
                {
                    b.OwnsOne("CHStore.Application.Core.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<long>("TransportCompanyId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("BIGINT")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<TimeSpan>("ClosingTime")
                                .HasColumnName("closing_time")
                                .HasColumnType("TIME");

                            b1.Property<string>("Complement")
                                .HasColumnName("complement")
                                .HasColumnType("VARCHAR(100)");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnName("number")
                                .HasColumnType("VARCHAR(15)");

                            b1.Property<TimeSpan>("OpeningTime")
                                .HasColumnName("opening_time")
                                .HasColumnType("TIME");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnName("street")
                                .HasColumnType("VARCHAR(300)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnName("zip_code")
                                .HasColumnType("VARCHAR(16)");

                            b1.HasKey("TransportCompanyId");

                            b1.ToTable("TransportCompany");

                            b1.WithOwner()
                                .HasForeignKey("TransportCompanyId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
