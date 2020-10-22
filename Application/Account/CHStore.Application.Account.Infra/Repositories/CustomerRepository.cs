using CHStore.Application.Account.Infra.Context;
using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Account.Domain.Entities;
using CHStore.Application.Account.Infra.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CHStore.Application.Account.Infra.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly AccountContext _context;
        
        public CustomerRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer> Get(string term)
        {
            var customers = await _context.Customers
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
                                          .Where(x => x.CPF == cpf)
                                          .ToListAsync();

            return customers.FirstOrDefault();
        }

        public async Task<Customer> GetByEmail(string username)
        {
            var customers = await _context.Customers
                                          .Where(x => x.Email.ToLower() == username)
                                          .ToListAsync();
            
            return customers.FirstOrDefault();
        }

        public async Task<IList<Customer>> Search(string term)
        {
            var customers = await _context.Customers
                                          .Where(
                                                    x =>
                                                        x.Email.ToLower().Contains(term) ||
                                                        x.CPF.Contains(term) ||
                                                        x.CNPJ.Contains(term) ||
                                                        x.Name.ToLower().Contains(term)
                                                ).ToListAsync();

            return customers;
        }

        public async Task<IList<Customer>> SearchByCNPJ(string cnpj)
        {
            var customers = await _context.Customers
                                          .Where(x => x.CNPJ.Contains(cnpj))
                                          .ToListAsync();

            return customers;
        }

        public async Task<IList<Customer>> SearchByCPF(string cpf)
        {
            var customers = await _context.Customers
                                          .Where(x => x.CPF.Contains(cpf))
                                          .ToListAsync();

            return customers;
        }

        public async Task<IList<Customer>> SearchByEmail(string email)
        {
            var customers = await _context.Customers
                                          .Where(x => x.Email.ToLower().Contains(email))
                                          .ToListAsync();

            return customers;
        }
    }
}
