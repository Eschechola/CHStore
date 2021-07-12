using System;
using System.Collections.Generic;

namespace CHStore.Database.Entities
{
    public abstract class Entity
    {
        public long Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        private List<string> _errors;

        public IReadOnlyCollection<string> Errors
        {
            get { return _errors; }
            set { }
        }

        protected Entity()
        {
            _errors = new List<string>();
        }
    }
}
