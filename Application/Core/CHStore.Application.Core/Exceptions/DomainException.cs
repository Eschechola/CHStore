using System;

namespace CHStore.Application.Core.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException()
        {}

        public DomainException(string message) : base(message)
        {}
    }
}
