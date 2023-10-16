using System;

namespace Catalog.API.Application.Exceptions
{
    public sealed class IncorrectPasswordException : BadRequestException
    {

        public IncorrectPasswordException(string message)
            : base(message)
        {
        }
    }
}