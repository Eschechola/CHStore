namespace CHStore.Database.Entities
{
    public class EmployeePermission : Entity
    {
        public long EmployeeId { get; private set; }
        public long PermissionId { get; private set; }
        
        public Employee Employee { get; private set; }
        public Permission Permission { get; private set; }

        protected EmployeePermission() { }

        public EmployeePermission(
            long employeeId,
            long permissionId
        )
        {
            EmployeeId = employeeId;
            PermissionId = permissionId;
        }
    }
}
