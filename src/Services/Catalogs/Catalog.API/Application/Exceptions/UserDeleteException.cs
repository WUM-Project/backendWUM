using System;

namespace Catalog.API.Application.Exceptions
{
    public sealed class UserDeleteException : BadRequestException
    {
        public UserDeleteException()
            : base("Could not delete user!!")
        {
        }

    }
}