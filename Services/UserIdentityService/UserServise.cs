using Interfaces;
using Microsoft.EntityFrameworkCore;
using UserIdentityService.Models;

namespace UserIdentityService
{
    public class UserServise : IUserService
    {
        private readonly WumaccountsContext db;

        public UserServise(WumaccountsContext context)
        {
            db = context;
        }


        public async Task<bool> CheckCredentialsAsync(string login, string password)
        {
            // Use the database context to check if there's a user with the provided login and password
            var user = await db.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
            return user != null;
        }


    }
}
