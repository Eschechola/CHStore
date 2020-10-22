using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Account.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace CHStore.Application.Account.Infra.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        IList<EmployeePermission> GetEmployeePermissions(long employeeId);
    }
}
