using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Catalog.API.Application.Pagginations;
using Catalog.API.Application.Services.Interfaces;



namespace Catalog.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriesController : ControllerBase
    {

        private readonly IServiceManager _serviceManager;
        public CategoriesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        [HttpGet]
  
        public async Task<IActionResult> GetCategories(
         CancellationToken cancellationToken = default)
        {
            Console.WriteLine("\n---> Getting All СategoriesE...");
            var result = await _serviceManager.CategoryService.GetAllAsync(cancellationToken);
            string lang ="uk";
           
  if (!String.IsNullOrEmpty(lang))
            {
           
              result = result?.Where(x => x.Lang?.Contains(lang.ToLower()) ?? false)?.ToList();
            }
         



            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IActionResult> GetChildCategories(int ParentId,
         CancellationToken cancellationToken = default)
        {
            Console.WriteLine("\n---> Getting All Сategories...");
            var result = await _serviceManager.CategoryService.GetAllChild(ParentId,cancellationToken);
            string lang ="uk";
           
  if (!String.IsNullOrEmpty(lang))
            {
           
              result = result?.Where(x => x.Lang?.Contains(lang.ToLower()) ?? false)?.ToList();
            }
         



            return Ok(result);
        }




   
   

  




    

      

    }
}