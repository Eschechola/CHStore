using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CHStore.Application.Sales.Infra.Context;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Core.Data.Interfaces;

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

        public async Task<IList<Order>> SearchByStatus(Status status)
        {
            return await _context.Orders
                                .AsNoTracking()
                                .Include(order => order.Status)
                                .Include(order => order.Voucher)
                                .Include(order => order.TransportCompany)
                                .Include(order => order.OrderProducts)
                                .Where
                                (
                                    x =>
                                        x.Status.Contains(status)
                                )
                                .ToListAsync();
        }

        public async Task<IList<Order>> SearchOrderBetweenDates(DateTime initialDate, DateTime finalDate)
        {
            return await _context.Orders
                                .AsNoTracking()
                                .Include(order => order.Status)
                                .Include(order => order.Voucher)
                                .Include(order => order.TransportCompany)
                                .Include(order => order.OrderProducts)
                                .Where
                                (
                                    x =>
                                        x.RequestDate >= initialDate &&
                                        x.FinishDate <= finalDate
                                )
                                .ToListAsync();
        }

        public async Task<IList<Order>> SearchOrderBetweenPrices(decimal initialPrice, decimal finalPrice)
        {
            return await _context.Orders
                                .AsNoTracking()
                                .Include(order => order.Status)
                                .Include(order => order.Voucher)
                                .Include(order => order.TransportCompany)
                                .Include(order => order.OrderProducts)
                                .Where
                                (
                                    x =>
                                        x.ProductsPrice >= initialPrice &&
                                        x.ProductsPrice <= finalPrice
                                )
                                .ToListAsync();
        }

        public async Task<IList<Order>> SearchOrdersByCustomerId(long customerId)
        {
            return await _context.Orders
                                .AsNoTracking()
                                .Include(order => order.Status)
                                .Include(order => order.Voucher)
                                .Include(order => order.TransportCompany)
                                .Include(order => order.OrderProducts)
                                .Include(order => order.Customer)
                                .Where
                                (
                                    x =>
                                        x.CustomerId == customerId
                                )
                                .ToListAsync();
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }
    }
}
