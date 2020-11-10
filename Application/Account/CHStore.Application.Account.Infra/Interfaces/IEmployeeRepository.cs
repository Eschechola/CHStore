using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Account.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using CHStore.Application.Core.Filters;

namespace CHStore.Application.Account.Infra.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>, IDisposable
    {
        Task<Employee> Get(string term); 
        Task<Employee> GetByUsername(string username);
        Task<Employee> GetByCPF(string cpf);
        Task<Employee> GetByEmail(string username);
        Task<IList<EmployeePermission>> GetEmployeePermissions(long employeeId);
        Task<IList<Employee>> Search(SearchEmployeeFilter searchFilter);
    }
}
