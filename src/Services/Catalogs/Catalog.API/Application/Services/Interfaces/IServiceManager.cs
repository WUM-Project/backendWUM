using System;

namespace Catalog.API.Application.Services.Interfaces
{
    public interface IServiceManager
    {
      
        ICategoryService CategoryService { get; }
        IProductService ProductService { get; }
        IUploadService UploadService { get; }
    }
}