using CHStore.Application.Core.Data.Context;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Sales.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CHStore.Application.Sales.Infra.Context
{
    public class SalesContext : BaseContext<SalesContext>
    {
        #region Constructors

        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions<SalesContext> options)
            : base(options)
        {
        }

        #endregion

        #region DBSets

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TransportCompany> TransportCompanies { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new OrderProductMap());
            builder.ApplyConfiguration(new StatusMap());
            builder.ApplyConfiguration(new TransportCompanyMap());
            builder.ApplyConfiguration(new VoucherMap());

            base.OnModelCreating(builder);
        }

        #endregion
    }
}
