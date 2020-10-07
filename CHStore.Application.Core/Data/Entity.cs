namespace CHStore.Application.Core.Data
{
    public abstract class Entity
    {
        public long Id { get; private set; }

        protected Entity(long id)
        {
            Id = id;
        }
    }
}
