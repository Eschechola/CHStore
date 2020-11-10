using System.Linq;
using System.Threading.Tasks;
using CHStore.Application.Account.Domain.Entities;
using CHStore.Application.Account.Infra.Context;
using CHStore.Application.Account.Infra.Interfaces;
using CHStore.Application.Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Filters;

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

        public async Task<IList<Employee>> Search(SearchEmployeeFilter searchFilter)
        {
            IQueryable<Employee> allEmployees = _context.Employees;

            if (searchFilter.EmployeeId != 0)
                return await allEmployees.Where(x => x.Id == searchFilter.EmployeeId)
                                         .ToListAsync();

            if (searchFilter.OnlyActives)
                allEmployees = allEmployees.Where(x => x.Active == true);

            if (!string.IsNullOrEmpty(searchFilter.Name))
                allEmployees = allEmployees.Where(x => x.Name.ToLower().Contains(searchFilter.Name.ToLower()));

            if (!string.IsNullOrEmpty(searchFilter.Username))
                allEmployees = allEmployees.Where(x => x.Username.ToLower().Contains(searchFilter.Username.ToLower()));

            if (!string.IsNullOrEmpty(searchFilter.CPF))
                allEmployees = allEmployees.Where(x => x.CPF.Contains(searchFilter.CPF));

            if (!string.IsNullOrEmpty(searchFilter.Email))
                allEmployees = allEmployees.Where(x => x.Email.ToLower().Contains(searchFilter.Email.ToLower()));

            return await allEmployees
                            .AsNoTracking()
                            .ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
