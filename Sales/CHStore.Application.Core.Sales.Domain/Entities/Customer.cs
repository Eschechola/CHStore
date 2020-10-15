using System.Collections.Generic;
using CHStore.Application.Core.Data;

namespace CHStore.Application.Sales.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; private set; }

        public IList<Order> Orders { get; private set; }

        public Customer(string name)
        {
            Name = name;
        }

        public void SetOrderList(IList<Order> orders) => Orders = orders;
    }
}
