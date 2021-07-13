using CHStore.Application.Core.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CHStore.Application.Core.Data.Context
{
    public abstract class BaseContext<T> : DbContext, IUnitOfWork
       where T : DbContext
    {
        public BaseContext()
        {
        }

        public BaseContext(DbContextOptions<T> options)
            : base(options)
        {
        }

        public void BeginTransaction()
            => this.Database.BeginTransaction();
        
        public async Task BeginTransactionAsync()
            => await this.Database.BeginTransactionAsync();

        public void Commit()
            => this.Database.CommitTransaction();

        public async Task CommitAsync()
            => await this.Database.CommitTransactionAsync();

        public void Rollback()
            => this.Database.RollbackTransaction();

        public async Task RollbackAsync()
            => await this.Database.RollbackTransactionAsync();

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is Entity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                    ((Entity)entity.Entity).CreatedAtNow();

                ((Entity)entity.Entity).UpdatedAtNow();
            }
        }
    }
}
