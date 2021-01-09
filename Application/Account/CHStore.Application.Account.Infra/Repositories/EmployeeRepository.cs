using System.Linq;
using System.Threading.Tasks;
using CHStore.Application.Account.Domain.Entities;
using CHStore.Application.Account.Infra.Context;
using CHStore.Application.Account.Infra.Interfaces;
using CHStore.Application.Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CHStore.Application.Core.Data.Interfaces;

namespace CHStore.Application.Account.Infra.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly AccountContext _context;

        public EmployeeRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Employee> Get(string term)
        {
            var employees = await _context.Employees
                                          .AsNoTracking()
                                          .Where(
                                               x =>
                                                   x.CPF == term ||
                                                   x.Username == term ||
                                                   x.Email.ToLower() == term.ToLower()
                                           )
                                          .ToListAsync();

            return employees.FirstOrDefault();
        }

        public async Task<Employee> GetByCPF(string cpf)
        {
            var employees = await _context.Employees
                                         .AsNoTracking()
                                         .Where(x => x.CPF == cpf)
                                         .ToListAsync();

            return employees.FirstOrDefault();
        }

        public async Task<Employee> GetByEmail(string email)
        {
            var employees = await _context.Employees
                                         .AsNoTracking()
                                         .Where(x => x.Email.ToLower() == email.ToLower())
                                         .ToListAsync();

            return employees.FirstOrDefault();
        }

        public async Task<Employee> GetByUsername(string username)
        {
            var employees = await _context.Employees
                                         .AsNoTracking()
                                         .Where(x => x.Username == username)
                                         .ToListAsync();

            return employees.FirstOrDefault();
        }

        public async Task<IList<EmployeePermission>> GetEmployeePermissions(long employeeId)
        {
            var permissions = await _context.EmployeesPermissions
                                      .AsNoTracking()
                                      .Where(x => x.EmployeeId == employeeId)
                                      .Include(x => x.Permission)
                                      .ToListAsync();

            return permissions;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
