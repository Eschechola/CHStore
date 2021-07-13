using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Account.Infra.Context;
using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Account.Domain.Entities;
using CHStore.Application.Account.Infra.Interfaces;

namespace CHStore.Application.Account.Infra.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly AccountContext _context;

        public CustomerRepository(AccountContext context)
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
