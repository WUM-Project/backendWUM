using System;

namespace Catalog.API.Application.Exceptions
{
    public sealed class InvalidTokenException : BadRequestException
    {
        public InvalidTokenException()
            :base("Invalid tokens!!")
        {
        }
    }
}
