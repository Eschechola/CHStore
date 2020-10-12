using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Sales.DomainServices.Interfaces;

namespace CHStore.Application.Sales.DomainServices.Services
{
    public class SalesService : ISalesService
    {
        public Task<Order> CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrder(long orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Order>> SearchOrdersByUserId(long userId)
        {
            throw new NotImplementedException();
        }
    }
}
