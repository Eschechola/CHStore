using CHStore.Application.Core.Data;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Exceptions;
using System.Collections.Generic;

namespace CHStore.Application.Core.Catalog.Domain.Entities
{
    public class Category : Entity, IAggregateRoot
    {
        #region Properties

        public string Name { get; private set; }

        public IList<Product> Products { get; private set; }

        #endregion

        #region Constructors

        public Category(long id, string name) : base(id)
        {
            Name = name;
        }

        #endregion

        #region Methos

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainException("O Nome da categoria não pode ser vazio");

            Name = name;
        }

        public bool Validate()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
