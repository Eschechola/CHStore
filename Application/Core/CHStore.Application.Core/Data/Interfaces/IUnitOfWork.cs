using System.Threading.Tasks;

namespace CHStore.Application.Core.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
