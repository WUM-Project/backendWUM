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
    public class ProductsController : ControllerBase
    {

        private readonly IServiceManager _serviceManager;
           private readonly IWebHostEnvironment environment;
        public ProductsController(IServiceManager serviceManager, IWebHostEnvironment environment)
        {  this.environment = environment;
            _serviceManager = serviceManager;
        }


        [HttpGet]
  
        public async Task<IActionResult> GetProducts(
         CancellationToken cancellationToken = default)
        {
       
            Console.WriteLine("\n---> Getting All Product...");
          
            var result = await _serviceManager.ProductService.GetAllAsync(cancellationToken);
            string lang ="uk";
             Console.WriteLine(result);
  if (!String.IsNullOrEmpty(lang))
            {
           
              result = result?.Where(x => x.Lang?.Contains(lang.ToLower()) ?? false)?.ToList();
            }
         



            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetChildProducts(int ParentId,
         CancellationToken cancellationToken = default)
        {
            Console.WriteLine("\n---> Getting All Сategories...");
            var result = await _serviceManager.ProductService.FindAllProduct(ParentId,cancellationToken);
            string lang ="uk";
           
  if (!String.IsNullOrEmpty(lang))
            {
           
              result = result?.Where(x => x.Lang?.Contains(lang.ToLower()) ?? false)?.ToList();
            }
         

         

            return Ok(result);
        }
    
        




   
   

  




    

      

    }
}