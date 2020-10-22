﻿using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Account.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHStore.Application.Account.Infra.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<Employee> Get(string term); 
        Task<Employee> GetByUsername(string username);
        Task<Employee> GetByCPF(string cpf);
        Task<Employee> GetByEmail(string username);
        Task<IList<EmployeePermission>> GetEmployeePermissions(long employeeId);
        Task<IList<Employee>> Search(string term);
        Task<IList<Employee>> SearchByEmail(string email);
        Task<IList<Employee>> SearchByCPF(string cpf);
        Task<IList<Employee>> SearchByUsername(string username);
    }
}
