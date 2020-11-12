using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Account.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using CHStore.Application.Core.Filters;

namespace CHStore.Application.Account.Infra.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>, IDisposable
    {
        Task<Customer> Get(string term);
        Task<Customer> GetByCPF(string cpf);
        Task<Customer> GetByCNPJ(string cnpj);
        Task<Customer> GetByEmail(string username);
        Task<IList<Customer>> Search(SearchCustomerFilter searchFilter);
    }
}
