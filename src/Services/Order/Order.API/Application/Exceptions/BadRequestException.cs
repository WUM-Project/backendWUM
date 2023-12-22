using System;


namespace Order.Api.Application.Exceptions
{
    public abstract class BadRequestException : Exception 
    {
        protected BadRequestException(string message)
            : base(message)
        {
        }
    }
}
