namespace Interfaces
{

    public interface IUserService
    { 


        Task<bool> CheckCredentialsAsync(string login, string password);


    }

}