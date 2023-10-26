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
using Catalog.Domain.Entities;
using System.IO;



namespace Catalog.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UploadsController : ControllerBase
    {

        private readonly IServiceManager _serviceManager;
           private readonly IWebHostEnvironment environment;
        public UploadsController(IServiceManager serviceManager, IWebHostEnvironment environment)
        {  this.environment = environment;
            _serviceManager = serviceManager;
        }
          [HttpPost]
           [Route("UploadImage")]
           //Add single upload image
        public async Task<IActionResult> UploadToFileSystem(List<IFormFile> files, string FolderName)
        {
            int passcount = 0;int errorcount = 0;
              try
          {
                // var response =null;
            foreach (var file in files)
            {   
                var basePath = Path.Combine("wwwroot\\Uploads\\" + FolderName);
                bool basePathExists = System.IO.Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
               
                var mainPath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}"+ "/Uploads/" + FolderName;
                var currentPath =Path.Combine(mainPath, file.FileName);
                // this.environment.WebRootPath + "\\Upload\\product\\"
                 var filePath = Path.Combine(basePath, file.FileName);
                var extension = Path.GetExtension(file.FileName);
                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        passcount++;
                    }
                    var fileModel = new UploadedFiles
                    {
                        CreatedAt = DateTime.UtcNow,
                        FileType = file.ContentType,
                        Extension = extension,
                        Name = fileName,
                        // Description = description,
                        FilePath = currentPath
                    };
               await  _serviceManager.UploadService.CreateAsync(fileModel);
                 
                    // context.SaveChanges();
                }
            }
         }
           catch(Exception ex){
            errorcount++;
            Console.WriteLine(ex);
            // return ex;
           }
                return Ok(passcount + " Files uploaded &" + errorcount + " files failed");
           
        }





   
   

  




    

      

    }
}