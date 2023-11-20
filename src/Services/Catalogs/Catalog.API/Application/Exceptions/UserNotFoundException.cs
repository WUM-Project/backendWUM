using System;

namespace Catalog.API.Application.Exceptions
{
    public sealed class UserNotFoundException : NotFoundException
    {
     
        public UserNotFoundException()
            : base($"The file   was not found")
        {
        }
        public UserNotFoundException(int Id)
            : base($"The file with id {Id}   was not found")
        {
        }

        public UserNotFoundException(int Id, string message)
            :base($"Error delete user id = {Id}. {message}")
        {
        }

    }
}
