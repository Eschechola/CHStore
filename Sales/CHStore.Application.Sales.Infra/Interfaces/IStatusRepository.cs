using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Sales.Domain.Entities;
using System;

namespace CHStore.Application.Sales.Infra.Interfaces
{
    public interface IStatusRepository : IBaseRepository<Status>, IDisposable
    {}
}
