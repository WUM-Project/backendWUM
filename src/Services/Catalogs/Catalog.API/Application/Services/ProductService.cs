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
        public async Task<IEnumerable<ProductReadDto>> FindAllProduct(int ParentId,CancellationToken cancellationToken = default)
        {
            var categories = await _repositoryManager.ProductRepository.FindAllAsync(x=>x.ImageId == ParentId );
     
            var productDto = _mapper.Map<IEnumerable<ProductReadDto>>(categories);

           

            return productDto;
        }

    
    }

}
