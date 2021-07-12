using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Data.Interfaces;
using System;

namespace CHStore.Application.Core.Catalog.Infra.Data.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
    }
}
