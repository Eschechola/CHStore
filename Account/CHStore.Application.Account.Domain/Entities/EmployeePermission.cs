using CHStore.Application.Core.Data;

namespace CHStore.Application.Account.Domain.Entities
{
    public class EmployeePermission : Entity
    {
        public long EmployeeId { get; private set; }
        public long PermissionId { get; private set; }
        
        public Employee Employee { get; private set; }
        public Permission Permission { get; private set; }

        public EmployeePermission(
            long employeeId,
            long permissionId,
            Employee employee,
            Permission permission
        )
        {
            EmployeeId = employeeId;
            PermissionId = permissionId;
            Employee = employee;
            Permission = permission;
        }
    }
}
