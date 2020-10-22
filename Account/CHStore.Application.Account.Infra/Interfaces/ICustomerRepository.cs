using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Account.Domain.Entities;

namespace CHStore.Application.Account.Infra.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
    }
}
