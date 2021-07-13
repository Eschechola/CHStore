using System.Collections.Generic;
using CHStore.Application.Core.Data;

namespace CHStore.Application.Sales.Domain.Entities
{
    public class Customer : Entity
    {
        #region Properties

        public string Name { get; private set; }

        //Ef Properties
        public IList<Order> Orders { get; private set; }

        #endregion

        #region Constructors

        protected Customer()
        {
        }

        public Customer(string name)
        {
            Name = name;
        }

        #endregion

        #region Methods

        public void SetOrderList(IList<Order> orders) => Orders = orders;

        #endregion
    }
}
