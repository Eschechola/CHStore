using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Filters;
using CHStore.Application.Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHStore.Application.Sales.Infra.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>, IDisposable
    {
        Task<IList<Order>> Search(SearchOrderFilter searchFilter);
    }
}
