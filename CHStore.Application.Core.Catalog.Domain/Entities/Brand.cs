using CHStore.Application.Core.Data;
using CHStore.Application.Core.Exceptions;
using System.Collections.Generic;

namespace CHStore.Application.Core.Catalog.Domain.Entities
{
    public class Brand : Entity
    {
        #region Properties

        public string Name { get; private set; }

        public IList<Product> Products { get; private set; }

        #endregion

        #region Constructors

        public Brand(long id, string name) : base(id)
        {
            Name = name;
        }

        #endregion

        #region Methos

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainException("O Nome da marca não pode ser vazio");

            Name = name;
        }

        #endregion
    }
}
