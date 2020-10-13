using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Sales.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CHStore.Application.Sales.Infra.Context
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        { }

        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        { }

        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TransportCompany> TransportCompanies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-652APCE\SQLEXPRESS;Initial Catalog=CHSTORE;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CouponMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new StatusMap());
            builder.ApplyConfiguration(new TransportCompanyMap());
        }
    }
}
