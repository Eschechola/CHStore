using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CHStore.Application.Core.Data.Interfaces;
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

        public override IUnitOfWork UnitOfWork
        {
            get { return _context; }
            protected set { UnitOfWork = value; }
        }

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

        public async Task<Customer> GetByCNPJ(string cnpj)
        {
            var customers = await _context.Customers
                                          .AsNoTracking()
                                          .Where(x => x.CNPJ == cnpj)
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

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
