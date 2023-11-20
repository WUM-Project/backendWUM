using System;
using AutoMapper;
using Microsoft.Extensions.Options;

using Catalog.API.Grpc;
using Catalog.Domain.Repositories;
using Catalog.API.Application.Services.Interfaces;
using Catalog.API.Application.Configurations;
using Microsoft.Extensions.Configuration;
// using Catalog.API.Grpc.Interfaces;
using Catalog.API.Application.Contracts.Infrastructure;
using Catalog.Domain.Entities;

namespace Catalog.API.Application.Services
{
    public class ServiceManager : IServiceManager
    {   
        

        private readonly Lazy<ICategoryService> _lazyCategoryService;
        private readonly Lazy<IProductService> _lazyProductService;
        private readonly Lazy<IUploadService> _lazyUploadService;
 

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, 
            IOptionsMonitor<JwtConfig> optionsMonitor, IEmailService emailService)
        {
           
            _lazyCategoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, mapper));
            _lazyProductService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper));
            _lazyUploadService = new Lazy<IUploadService>(() => new UploadService(repositoryManager, mapper));
            
            // reportGrpcService, examGrpcService,
        }

  
        public ICategoryService CategoryService => _lazyCategoryService.Value;
        public IProductService ProductService => _lazyProductService.Value;
        public IUploadService UploadService => _lazyUploadService.Value;
    }

}