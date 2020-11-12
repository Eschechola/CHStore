﻿// <auto-generated />
using System;
using CHStore.Application.Account.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CHStore.Application.Account.Infra.Migrations
{
    [DbContext(typeof(AccountContext))]
    partial class AccountContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CHStore.Application.Account.Domain.Entities.Customer", b =>
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
                        .HasDefaultValue(true);

                    b.Property<string>("CNPJ")
                        .HasColumnName("cnpj")
                        .HasColumnType("VARCHAR(14)")
                        .HasMaxLength(11);

                    b.Property<string>("CPF")
                        .HasColumnName("cpf")
                        .HasColumnType("VARCHAR(11)")
                        .HasMaxLength(11);

                    b.Property<long>("DocumentType")
                        .HasColumnName("document_type")
                        .HasColumnType("BIGINT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("VARCHAR(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("RegisterDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("register_date")
                        .HasColumnType("DATETIME")
                        .HasDefaultValue(new DateTime(2020, 11, 12, 0, 14, 26, 890, DateTimeKind.Local).AddTicks(4697));

                    b.HasKey("Id");

                    b.HasIndex("CNPJ")
                        .IsUnique()
                        .HasFilter("[cnpj] IS NOT NULL");

                    b.HasIndex("CPF")
                        .IsUnique()
                        .HasFilter("[cpf] IS NOT NULL");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CHStore.Application.Account.Domain.Entities.Employee", b =>
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
                        .HasDefaultValue(true);

                    b.Property<string>("CPF")
                        .HasColumnName("cpf")
                        .HasColumnType("VARCHAR(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("VARCHAR(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("RegisterDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("register_date")
                        .HasColumnType("DATETIME")
                        .HasDefaultValue(new DateTime(2020, 11, 12, 0, 14, 26, 928, DateTimeKind.Local).AddTicks(6996));

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CPF")
                        .IsUnique()
                        .HasFilter("[cpf] IS NOT NULL");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("CHStore.Application.Account.Domain.Entities.EmployeePermission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("EmployeeId")
                        .HasColumnName("fk_employee_id")
                        .HasColumnType("BIGINT");

                    b.Property<long>("PermissionId")
                        .HasColumnName("fk_permission_id")
                        .HasColumnType("BIGINT");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PermissionId");

                    b.ToTable("Employee_X_Permission");
                });

            modelBuilder.Entity("CHStore.Application.Account.Domain.Entities.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("CHStore.Application.Account.Domain.Entities.Customer", b =>
                {
                    b.OwnsOne("CHStore.Application.Core.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<long>("CustomerId")
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

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });
                });

            modelBuilder.Entity("CHStore.Application.Account.Domain.Entities.Employee", b =>
                {
                    b.OwnsOne("CHStore.Application.Core.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<long>("EmployeeId")
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

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employee");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });
                });

            modelBuilder.Entity("CHStore.Application.Account.Domain.Entities.EmployeePermission", b =>
                {
                    b.HasOne("CHStore.Application.Account.Domain.Entities.Employee", "Employee")
                        .WithMany("EmployeePermissions")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("fk_employee_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CHStore.Application.Account.Domain.Entities.Permission", "Permission")
                        .WithMany("EmployeePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
