using System;


namespace Order.Api.Application.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message)
            : base(message)
        {
        }
    }
}