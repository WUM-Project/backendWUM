using System;
using System.Net;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Catalog.API.Application.Exceptions;
using Catalog.API.Application.Configurations;
using Catalog.API.Application.Services.Interfaces;
using Catalog.API.Application.Contracts.Dtos.ProductDtos;

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Catalog.API.Grpc;
using System.Linq.Expressions;
using Grpc.Net.Client;
//using GrpcExam;
using Microsoft.Extensions.Configuration;
// using Catalog.API.Grpc.Interfaces;
using Catalog.API.Application.Contracts.Infrastructure;
using Catalog.API.Application.Models;

namespace Catalog.API.Application.Services
{
    internal sealed class ProductService : IProductService
    {


        private readonly IMapper _mapper;
  
        private readonly IRepositoryManager _repositoryManager;

 public ProductService(IRepositoryManager repositoryManager, IMapper mapper
      )
        {
            _mapper = mapper;
         ;
            _repositoryManager = repositoryManager;
            // _reportGrpcService = reportGrpcService;
            // _examGrpcService = examGrpcService;
        }
        public async Task<IEnumerable<ProductReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _repositoryManager.ProductRepository.GetAllAsync(cancellationToken);
       
            var productDto = _mapper.Map<IEnumerable<ProductReadDto>>(categories);

           

            return productDto;
        }
        public async Task<IEnumerable<ProductCatalogDto>> FindAllProduct(Expression<Func<Product, bool>> predicate,CancellationToken cancellationToken = default)
        {
            var categories = await _repositoryManager.ProductRepository.FindAllAsync(predicate,cancellationToken);
     
            var productDto = _mapper.Map<IEnumerable<ProductCatalogDto>>(categories);

           

            return productDto;
        }
           public async Task<ProductReadDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {

            var product = await _repositoryManager.ProductRepository.GetByIdAsync(id, cancellationToken);

            if (product is null)
            {
                throw new UserNotFoundException(id);
            }

            var productDto = _mapper.Map<ProductReadDto>(product);
            
            // userDto.UploadedFiles = String.Join(",", user.UploadedFiles.ToArray().Select(x => x.Name).ToArray());

            return productDto;
        }

    
    }

}
