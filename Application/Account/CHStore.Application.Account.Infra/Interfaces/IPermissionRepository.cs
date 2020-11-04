using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Account.Domain.Entities;
using System;

namespace CHStore.Application.Account.Infra.Interfaces
{
    public interface IPermissionRepository : IBaseRepository<Permission>, IDisposable
    {
    }
}
