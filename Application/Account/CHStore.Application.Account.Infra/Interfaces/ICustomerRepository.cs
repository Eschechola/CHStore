using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Account.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace CHStore.Application.Account.Infra.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>, IDisposable
    {
        Task<Customer> Get(string term);
        Task<Customer> GetByCPF(string cpf);
        Task<Customer> GetByEmail(string username);
        Task<IList<Customer>> Search(string term);
        Task<IList<Customer>> SearchByEmail(string email);
        Task<IList<Customer>> SearchByCPF(string cpf);
        Task<IList<Customer>> SearchByCNPJ(string cnpj);
    }
}
