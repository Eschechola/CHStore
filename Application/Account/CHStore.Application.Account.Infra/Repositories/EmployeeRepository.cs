using System.Linq;
using System.Threading.Tasks;
using CHStore.Application.Account.Domain.Entities;
using CHStore.Application.Account.Infra.Context;
using CHStore.Application.Account.Infra.Interfaces;
using CHStore.Application.Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CHStore.Application.Account.Infra.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly AccountContext _context;

        public EmployeeRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Employee> Get(string term)
        {
            var employees = await _context.Employees
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
                                         .Where(x => x.CPF == cpf)
                                         .ToListAsync();

            return employees.FirstOrDefault();
        }

        public async Task<Employee> GetByEmail(string email)
        {
            var employees = await _context.Employees
                                         .Where(x => x.Email.ToLower() == email.ToLower())
                                         .ToListAsync();

            return employees.FirstOrDefault();
        }

        public async Task<Employee> GetByUsername(string username)
        {
            var employees = await _context.Employees
                                         .Where(x => x.Username == username)
                                         .ToListAsync();

            return employees.FirstOrDefault();
        }

        public async Task<IList<EmployeePermission>> GetEmployeePermissions(long employeeId)
        {
            var permissions = await _context.EmployeesPermissions
                                      .Where(x => x.EmployeeId == employeeId)
                                      .Include(x => x.Permission)
                                      .ToListAsync();

            return permissions;
        }

        public async Task<IList<Employee>> Search(string term)
        {
            var employees = await _context.Employees
                                           .Where(
                                                x => 
                                                    x.CPF.Contains(term) ||
                                                    x.Username.ToLower().Contains(term) ||
                                                    x.Email.ToLower().Contains(term) ||
                                                    x.Name.ToLower().Contains(term)
                                            )
                                           .ToListAsync();

            return employees;
        }

        public async Task<IList<Employee>> SearchByCPF(string cpf)
        {
            var employees = await _context.Employees
                                           .Where(x => x.CPF == cpf)
                                           .ToListAsync();

            return employees;
        }

        public async Task<IList<Employee>> SearchByEmail(string email)
        {
            var employees = await _context.Employees
                                          .Where(x => x.Email.ToLower().Contains(email))
                                          .ToListAsync();

            return employees;
        }

        public async Task<IList<Employee>> SearchByUsername(string username)
        {
            var employees = await _context.Employees
                                          .Where(x => x.Username.ToLower().Contains(username))
                                          .ToListAsync();

            return employees;
        }
    }
}
