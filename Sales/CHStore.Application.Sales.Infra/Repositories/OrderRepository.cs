﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CHStore.Application.Sales.Infra.Context;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Core.Data.Repositories;

namespace CHStore.Application.Sales.Infra.Interfaces
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly SalesContext _context;

        public OrderRepository(SalesContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<Order>> SearchByStatus(Status status)
        {
            return await _context.Orders
                                .AsNoTracking()
                                .Include(order => order.Status)
                                .Include(order => order.Coupon)
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
                                .Include(order => order.Coupon)
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
                                .Include(order => order.Coupon)
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

        public async Task<IList<Order>> SearchOrdersByUserId(long userId)
        {
            return await _context.Orders
                                .AsNoTracking()
                                .Include(order => order.Status)
                                .Include(order => order.Coupon)
                                .Include(order => order.TransportCompany)
                                .Include(order => order.OrderProducts)
                                .Include(order => order.User)
                                .Where
                                (
                                    x =>
                                        x.UserId == userId
                                )
                                .ToListAsync();
        }
    }
}
