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
                            Path = filePath,
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
          [HttpPost]
           [Route("SingleUploadImage")]
           //Add single upload image
        public async Task<IActionResult> UploadFileSystem(IFormFile file, string FolderName)
        {
        //    APIResponse response=new APIResponse();
        //       try
        //   {
                // var response =null;
                Console.WriteLine(file);
                 UploadedFiles result = new UploadedFiles();
                var basePath = Path.Combine("wwwroot\\Uploads\\" + FolderName);
                bool basePathExists = System.IO.Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            //    Path.GetFileName(FileInput.PostedFile.FileName)+"_"+System.DateTime.Now.ToShortTimeString();
                var mainPath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}"+ "/Uploads/" + FolderName;
               
                // this.environment.WebRootPath + "\\Upload\\product\\"
              var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
               var fileExtension = Path.GetExtension(file.FileName);
               var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
               var newFileName = $"{fileNameWithoutExtension}_{timestamp}{fileExtension}";
                 var filePath = Path.Combine(basePath, newFileName);
                //  var filePath = Path.Combine(basePath, file.FileName);
                  var currentPath =Path.Combine(mainPath, newFileName);
                var extension = Path.GetExtension(file.FileName);
                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                      
                    }
                    var fileModel = new UploadedFiles
                    {
                        CreatedAt = DateTime.UtcNow,
                        FileType = file.ContentType,
                        Extension = extension,
                        Name = newFileName,
                        // Name = fileName,
                        Path = filePath,
                        // Description = description,
                        FilePath = currentPath
                    };
             result=  await  _serviceManager.UploadService.CreateAsync(fileModel);
                //   response.Result= result;
                
                    // context.SaveChanges();
                 
            }
            return Ok(result);
        //  }
        //    catch(Exception ex){
        
        //     Console.WriteLine(ex);
        //     // return ex;
        //    }
           
                // return Ok(passcount + " Files uploaded &" + errorcount + " files failed");
           
        }





   
   

        [HttpDelete("{id}")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            Console.WriteLine($"\n---> Delete File: {id} ....");
            var result =  await _serviceManager.UploadService.GetByIdAsync(id);
            
           
            if(result.Path != null){
              if (System.IO.File.Exists(result.Path))
            {
                System.IO.File.Delete(result.Path);
            }
            }
            await _serviceManager.UploadService.DeleteAsync(id);

            return NoContent();
        }

  




    

      

    }
}