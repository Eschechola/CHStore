using CHStore.Application.Core.Data;

namespace CHStore.Application.Account.Domain.Entities
{
    public class EmployeePermission : Entity
    {
        #region Properties

        public long EmployeeId { get; private set; }
        public long PermissionId { get; private set; }
        
        //EF Properties
        public Employee Employee { get; private set; }
        public Permission Permission { get; private set; }

        #endregion

        #region Constructors

        protected EmployeePermission() 
        {
        }

        public EmployeePermission(
            long employeeId,
            long permissionId
        )
        {
            EmployeeId = employeeId;
            PermissionId = permissionId;
        }

        #endregion
    }
}
