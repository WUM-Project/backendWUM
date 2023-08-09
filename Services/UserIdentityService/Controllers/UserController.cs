using Interfaces;
using Microsoft.AspNetCore.Mvc;

/*
Scaffold-DbContext "Data Source=DESKTOP-9M6MTGC\\SQLEXPRESS02;Initial Catalog=WUMAccounts;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Project UserIdentityService
Scaffold-DbContext "Server=DESKTOP-9M6MTGC\SQLEXPRESS02;Database=WUMAccounts;Trusted_Connection=True; Trust Server Certificate=False;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Project UserIdentityService
Scaffold-DbContext "Server=DESKTOP-9M6MTGC\SQLEXPRESS02;Database=WUMAccounts;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=False;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Project UserIdentityService
*/
namespace UserIdentityService
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("credentials")]
        public async Task<IActionResult> CheckCredentials(string login, string password)
        {
            var isValidCredentials = await _userService.CheckCredentialsAsync(login, password);
            return Ok(isValidCredentials);
           
        }

        
    }
}
