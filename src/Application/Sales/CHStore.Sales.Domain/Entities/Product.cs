using CHStore.Application.Core.Data;
using System.Collections.Generic;

namespace CHStore.Application.Sales.Domain.Entities
{
    public class Product : Entity
    {
        #region Properties

        public string Name { get; private set; }
        public decimal Price { get; private set; }

        //EF Properties
        public IList<OrderProduct> OrderProducts { get; private set; }

        #endregion

        #region Constructors

        protected Product()
        {
        }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        #endregion
    }
}
