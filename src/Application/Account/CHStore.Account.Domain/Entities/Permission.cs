using CHStore.Application.Core.Data;
using CHStore.Application.Core.Data.Interfaces;
using System.Collections.Generic;

namespace CHStore.Application.Account.Domain.Entities
{
    public class Permission : Entity, IAggregateRoot
    {
        #region Properties

        public string Name { get; private set; }

        //EF Properties
        public IList<EmployeePermission> EmployeePermissions { get; set; }

        #endregion

        #region Constructors

        protected Permission()
        {
        }

        public Permission(string name)
        {
            Name = name;
        }

        #endregion

        #region Methods

        public bool Validate()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
