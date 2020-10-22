using Microsoft.EntityFrameworkCore;
using CHStore.Application.Account.Infra.Mapping;
using CHStore.Application.Account.Domain.Entities;

namespace CHStore.Application.Account.Infra.Context
{
    public class AccountContext : DbContext
    {
        public AccountContext()
        { }

        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        { }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<EmployeePermission> EmployeesPermissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-652APCE\SQLEXPRESS;Initial Catalog=CHSTORE;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new EmployeeMap());
            builder.ApplyConfiguration(new PermissionMap());
            builder.ApplyConfiguration(new EmployeePermissionMap());
        }
    }
}
