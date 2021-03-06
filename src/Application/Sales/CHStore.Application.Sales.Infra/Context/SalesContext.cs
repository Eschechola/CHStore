﻿using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Sales.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CHStore.Application.Sales.Infra.Context
{
    public class SalesContext : DbContext, IUnitOfWork
    {
        public SalesContext()
        { }

        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        { }

        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TransportCompany> TransportCompanies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-652APCE\SQLEXPRESS;Initial Catalog=CHSTORE;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new VoucherMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new StatusMap());
            builder.ApplyConfiguration(new TransportCompanyMap());
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
