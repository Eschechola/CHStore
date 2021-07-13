using Microsoft.EntityFrameworkCore;
using CHStore.Application.Account.Infra.Mapping;
using CHStore.Application.Core.Data.Context;
using CHStore.Application.Account.Domain.Entities;

namespace CHStore.Application.Account.Infra.Context
{
    public class AccountContext : BaseContext<AccountContext>
    {
        #region Constructors

        public AccountContext()
        {
        }

        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {
        }

        #endregion

        #region DBSets

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeePermission> EmployeePermissions { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new EmployeeMap());
            builder.ApplyConfiguration(new EmployeePermissionMap());
            builder.ApplyConfiguration(new PermissionMap());

            base.OnModelCreating(builder);
        }

        #endregion
    }
}
