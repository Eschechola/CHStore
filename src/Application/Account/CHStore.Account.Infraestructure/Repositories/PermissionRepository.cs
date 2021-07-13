using CHStore.Application.Account.Domain.Entities;
using CHStore.Application.Account.Infra.Context;
using CHStore.Application.Account.Infra.Interfaces;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Data.Repositories;

namespace CHStore.Application.Account.Infra.Repositories
{
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        private readonly AccountContext _context;

        public PermissionRepository(AccountContext context)
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
