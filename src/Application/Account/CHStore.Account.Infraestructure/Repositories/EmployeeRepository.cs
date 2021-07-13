using CHStore.Application.Account.Domain.Entities;
using CHStore.Application.Account.Infra.Context;
using CHStore.Application.Account.Infra.Interfaces;
using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Core.Data.Interfaces;

namespace CHStore.Application.Account.Infra.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly AccountContext _context;

        public EmployeeRepository(AccountContext context)
            : base(context)
        {
            _context = context;
        }

        public override IUnitOfWork UnitOfWork
        {
            get { return UoW; }
        }

        private IUnitOfWork UoW => _context;
    }
}
