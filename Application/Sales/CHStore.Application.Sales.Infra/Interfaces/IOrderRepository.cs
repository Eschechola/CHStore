using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHStore.Application.Sales.Infra.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>, IDisposable
    {
        Task<IList<Order>> SearchOrdersByCustomerId(long customerId);
        Task<IList<Order>> SearchOrderBetweenDates(DateTime initialDate, DateTime finalDate);
        Task<IList<Order>> SearchOrderBetweenPrices(decimal initialPrice, decimal finalPrice);
        Task<IList<Order>> SearchByStatus(Status status);
    }
}
