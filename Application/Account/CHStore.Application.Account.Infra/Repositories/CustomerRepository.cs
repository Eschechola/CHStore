using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Filters;
using CHStore.Application.Account.Infra.Context;
using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Account.Domain.Entities;
using CHStore.Application.Account.Infra.Interfaces;
using System.Collections.Generic;

namespace CHStore.Application.Account.Infra.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly AccountContext _context;
        
        public CustomerRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Customer> Get(string term)
        {
            var customers = await _context.Customers
                                          .AsNoTracking()
                                          .Where(
                                                    x =>
                                                        x.Email.ToLower() == term ||
                                                        x.CPF == term ||
                                                        x.CNPJ == term
                                                ).ToListAsync();

            return customers.FirstOrDefault();
        }

        public async Task<Customer> GetByCPF(string cpf)
        {
            var customers = await _context.Customers
                                          .AsNoTracking()
                                          .Where(x => x.CPF == cpf)
                                          .ToListAsync();

            return customers.FirstOrDefault();
        }

        public async Task<Customer> GetByEmail(string username)
        {
            var customers = await _context.Customers
                                          .AsNoTracking()
                                          .Where(x => x.Email.ToLower() == username)
                                          .ToListAsync();
            
            return customers.FirstOrDefault();
        }

        public async Task<IList<Customer>> Search(SearchCustomerFilter searchFilter)
        {
            IQueryable<Customer> allCustomers = _context.Customers;

            if (searchFilter.CustomerId != 0)
                return await allCustomers.Where(x => x.Id == searchFilter.CustomerId)
                                               .ToListAsync();

            if (searchFilter.OnlyActives)
                allCustomers = allCustomers.Where(x => x.Active == true);

            if (!string.IsNullOrEmpty(searchFilter.Name))
                allCustomers = allCustomers.Where(x => x.Name.ToLower().Contains(searchFilter.Name.ToLower()));

            if (!string.IsNullOrEmpty(searchFilter.CPFOrCNPJ))
                allCustomers = allCustomers.Where(
                                                    x =>
                                                        x.CPF.Contains(searchFilter.CPFOrCNPJ) ||
                                                        x.CNPJ.Contains(searchFilter.CPFOrCNPJ)
                                                );

            if (!string.IsNullOrEmpty(searchFilter.Email))
                allCustomers = allCustomers.Where(x => x.Email.ToLower().Contains(searchFilter.Email.ToLower()));

            return await allCustomers
                            .AsNoTracking()
                            .ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
