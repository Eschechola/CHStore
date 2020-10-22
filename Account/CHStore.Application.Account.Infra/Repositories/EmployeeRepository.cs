using CHStore.Application.Account.Domain.Entities;
using CHStore.Application.Account.Infra.Context;
using CHStore.Application.Account.Infra.Interfaces;
using CHStore.Application.Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CHStore.Application.Account.Infra.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly AccountContext _context;

        public EmployeeRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public IList<EmployeePermission> GetEmployeePermissions(long employeeId)
        {
            var permissions = _context.EmployeesPermissions
                                      .Where(x => x.EmployeeId == employeeId)
                                      .Include(x => x.Permission)
                                      .ToList();

            return permissions;
        }
    }
}
