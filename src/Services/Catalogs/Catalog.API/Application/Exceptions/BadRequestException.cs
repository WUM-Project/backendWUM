using System;

namespace Catalog.API.Application.Exceptions
{
    public abstract class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }

        protected BadRequestException(string message, Exception innerException)
            : base(message)
        {
        }
    }
}
