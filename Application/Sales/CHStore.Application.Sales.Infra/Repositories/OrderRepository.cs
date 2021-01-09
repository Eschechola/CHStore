using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CHStore.Application.Sales.Infra.Context;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Core.Data.Interfaces;
using System.Linq.Expressions;

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

        public override async Task<IList<Order>> Search(Expression<Func<Order, bool>> expression)
        {
            var orders = await base.SearchQuery(expression);

            return await orders
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
