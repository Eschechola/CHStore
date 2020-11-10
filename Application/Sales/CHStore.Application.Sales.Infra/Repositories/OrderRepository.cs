using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CHStore.Application.Sales.Infra.Context;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Filters;

namespace CHStore.Application.Sales.Infra.Interfaces
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly SalesContext _context;

        public OrderRepository(SalesContext context) : base(context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IList<Order>> Search(SearchOrderFilter searchFilter)
        {
            IQueryable<Order> allOrders = _context.Orders;

            if (searchFilter.OrderId != 0)
                return await allOrders.Where(x => x.Id == searchFilter.OrderId).ToListAsync();

            if (searchFilter.InitialPrice >= 0)
                allOrders = allOrders.Where(x => x.TotalPrice >= searchFilter.InitialPrice);

            if (searchFilter.FinalPrice <= 0)
                allOrders = allOrders.Where(x => x.TotalPrice <= searchFilter.FinalPrice);

            if (searchFilter.RequestDate != null)
                allOrders = allOrders.Where(x => x.RequestDate >= searchFilter.RequestDate);

            return await allOrders
                    .AsNoTracking()
                    .Include(order => order.Status)
                    .Include(order => order.Voucher)
                    .Include(order => order.TransportCompany)
                    .Include(order => order.OrderProducts)
                    .ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
