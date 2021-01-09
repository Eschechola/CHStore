using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Catalog.Domain.Entities;

namespace CHStore.Application.Core.Catalog.Infra.Data.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>, IDisposable
    {
    }
}
