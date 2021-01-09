using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Core.Data.Interfaces;

namespace CHStore.Application.Sales.Infra.Interfaces
{
    public interface IVoucherRepository : IBaseRepository<Voucher>, IDisposable
    {
    }
}
