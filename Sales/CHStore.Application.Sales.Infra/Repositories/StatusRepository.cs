using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Sales.Infra.Context;

namespace CHStore.Application.Sales.Infra.Interfaces
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        private readonly SalesContext _context;

        public StatusRepository(SalesContext context) : base(context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }
    }
}
