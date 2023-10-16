using System;

namespace Catalog.API.Application.Exceptions
{
    public sealed class InvalidLoginException : BadRequestException
    {
        public InvalidLoginException()
            : base($"Invalid login request")
        {
        }
    }
}