﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Core.Data.Interfaces;

namespace CHStore.Application.Sales.Infra.Interfaces
{
    public interface IVoucherRepository : IBaseRepository<Voucher>, IDisposable
    {
        Task<IList<Voucher>> SearchVoucherByCode(string code);
        Task<IList<Voucher>> SearchVoucherByCode(string code, bool searchActives = true);
        Task<IList<Voucher>> SearchVoucherBetweenDates(DateTime initialDate, DateTime finalDate);
        Task<IList<Voucher>> SearchVoucherBetweenDates(DateTime initialDate, DateTime finalDate, bool searchActives = true);
    }
}
