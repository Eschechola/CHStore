using System.Collections.Generic;

namespace CHStore.Database.Entities
{
    public class Permission : Entity
    {
        public string Name { get; private set; }

        public IList<EmployeePermission> EmployeePermissions { get; private set; }

        protected Permission()
        {
        }

        public Permission(string name)
        {
            Name = name;
        }
    }
}
