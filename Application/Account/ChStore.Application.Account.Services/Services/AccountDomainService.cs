using System.Collections.Generic;
using System.Threading.Tasks;
using CHStore.Application.Account.Domain.Entities;
using CHStore.Application.Account.DomainServices.Interfaces;
using CHStore.Application.Account.Infra.Interfaces;
using CHStore.Application.Core.Exceptions;
using CHStore.Application.Core.ExtensionMethods;
using CHStore.Application.Core.Filters;

namespace CHStore.Application.Account.DomainServices
{
    public class AccountDomainService : IAccountDomainService
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AccountDomainService(
            ICustomerRepository customerRepository,
            IPermissionRepository permissionRepository,
            IEmployeeRepository employeeRepository
        )
        {
            _customerRepository = customerRepository;
            _permissionRepository = permissionRepository;
            _employeeRepository = employeeRepository;
        }

        #region Employee

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            employee.Validate();

            var employeeCPFExists = await _employeeRepository.GetByCPF(employee.CPF);

            if (employeeCPFExists != null)
                throw new DomainException("O CPF informado já está cadastrado na nossa base de dados");

            var employeeUsernameExists = await _employeeRepository.GetByUsername(employee.Username);

            if (employeeUsernameExists != null)
                throw new DomainException("O usuário informado já está cadastrado na nossa base de dados");

            var employeeEmailExists = await _employeeRepository.GetByEmail(employee.Email);
            
            if (employeeEmailExists != null)
                throw new DomainException("O email informado já está cadastrado na nossa base de dados");

            await _employeeRepository.Add(employee);
            await _employeeRepository.UnitOfWork.Commit();

            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            employee.Validate();

            var employeeExists = await _employeeRepository.Get(employee.Id);

            if (employeeExists == null)
                throw new DomainException("O colaborador informado não existe na nossa base de dados");

            await _employeeRepository.Update(employee);
            await _employeeRepository.UnitOfWork.Commit();

            return employee;
        }

        public async Task<bool> AuthenticateEmployee(string login, string password)
        {
            login = login.FormatToLoginParammeter();

            var employee = await _employeeRepository.Get(login);

            if (employee == null)
                return false;

            return employee.Password == password;
        }

        public async Task<IList<EmployeePermission>> GetEmployeePermissions(long employeeId)
        {
            return await _employeeRepository.GetEmployeePermissions(employeeId);
        }

        public async Task AddEmployeePermission(long employeeId, Permission permission)
        {
            var employee = await _employeeRepository.Get(employeeId);

            if (employee == null)
                throw new DomainException("Colaborador não encontrado.");

            var employeePermission = new EmployeePermission(employeeId, permission.Id);
            employee.AddPermission(employeePermission);

            employee.Validate();
            await _employeeRepository.Update(employee);
            await _employeeRepository.UnitOfWork.Commit();
        }

        public async Task RemoveEmployeePermission(long employeeId, Permission permission)
        {
            var employee = await _employeeRepository.Get(employeeId);

            if (employee == null)
                throw new DomainException("Colaborador não encontrado.");

            var employeePermission = new EmployeePermission(employeeId, permission.Id);
            employee.RemovePermission(employeePermission);

            employee.Validate();
            await _employeeRepository.Update(employee);
            await _employeeRepository.UnitOfWork.Commit();
        }

        public async Task<IList<Employee>> SearchEmployee(SearchEmployeeFilter searchFilter)
        {
            return await _employeeRepository.Search(searchFilter);
        }

        #endregion

        #region Customer

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            customer.Validate();

            var customerExists = await _customerRepository.Get(customer.Id);

            if (customerExists != null)
                throw new DomainException("O colaborador informado já está cadastrado na nossa base de dados");

            var customerCPFExists = await _customerRepository.GetByCPF(customer.CPF);

            if (customerCPFExists != null)
                throw new DomainException("O CPF informado já está cadastrado na nossa base de dados");

            var customerCNPJExists = await _customerRepository.GetByCNPJ(customer.CNPJ);

            if (customerCNPJExists != null)
                throw new DomainException("O CNPJ informado já está cadastrado na nossa base de dados");

            var customerEmailExists = await _customerRepository.GetByEmail(customer.Email);

            if (customerEmailExists != null)
                throw new DomainException("O email informado já está cadastrado na nossa base de dados");

            await _customerRepository.Add(customer);
            await _customerRepository.UnitOfWork.Commit();

            return customer;
        }
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            customer.Validate();

            var customerExists = await _customerRepository.Get(customer.Id);

            if (customerExists == null)
                throw new DomainException("O cliente informado não existe na nossa base de dados");

            await _customerRepository.Update(customer);
            await _customerRepository.UnitOfWork.Commit();

            return customer;
        }

        public async Task<IList<Customer>> SearchCustomer(SearchCustomerFilter searchFilter)
        {
            return await _customerRepository.Search(searchFilter);
        }

        public async Task<bool> AuthenticateCustomer(string login, string password)
        {
            login = login.FormatToLoginParammeter();

            var employee = await _customerRepository.Get(login);

            if (employee == null)
                return false;

            return employee.Password == password;
        }

        #endregion

        #region Permission

        public async Task<IList<Permission>> GetAllPermissions()
        {
            return await _permissionRepository.Get();
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _customerRepository?.Dispose();
            _permissionRepository?.Dispose();
            _employeeRepository?.Dispose();
        }

        #endregion
    }
}
