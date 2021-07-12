using CHStore.Database.Maps;
using Microsoft.EntityFrameworkCore;

namespace CHStore.Database.Context
{
    public class ChContext : DbContext
    {
        public ChContext()
        { }

        public ChContext(DbContextOptions<ChContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BrandMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new EmployeeMap());
            builder.ApplyConfiguration(new EmployeePermissionMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new OrderProductMap());
            builder.ApplyConfiguration(new PermissionMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new StatusMap());
            builder.ApplyConfiguration(new TransportCompanyMap());
            builder.ApplyConfiguration(new VoucherMap());
        }
    }
}
