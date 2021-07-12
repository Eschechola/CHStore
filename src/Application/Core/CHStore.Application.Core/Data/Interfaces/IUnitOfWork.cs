using System.Threading;
using System.Threading.Tasks;

namespace CHStore.Application.Core.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        int SaveChanges();
        void Commit();
        void Rollback();

        Task BeginTransactionAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task CommitAsync();
        Task RollbackAsync();
    }
}
