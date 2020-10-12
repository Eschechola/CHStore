using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Sales.Domain.Entities;

namespace CHStore.Application.Sales.DomainServices.Interfaces
{
    public interface ISalesService
    {
        Task<Order> CreateOrder(Order order);
        Task<Order> GetOrder(long orderId);
        Task<IList<Order>> SearchOrdersByUserId(long userId);
    }
}
