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
using Catalog.API.Application.Contracts.Dtos.AttributeDtos;
using Catalog.API.Application.Contracts.Dtos.BrandDtos;
using Catalog.API.Application.Contracts.Dtos.UploadDtos;

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
        public async Task<IEnumerable<AttributeReadDto>> GetAllAttributesAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _repositoryManager.ProductRepository.GetAllAttributesAsync(cancellationToken);
            var attributeDto = categories.Select(p => new AttributeReadDto
            {
                Id = p.Id,

                Lang = p.Lang,

                Title = p.Title,


                Values = p.Products
        .GroupBy(item => item.Value)
        .Select(group => new AttributeProductDto
        {
            AttributeId = group.First().AttributeId,
            Value = group.First().Value,
            Count = group.Count() // Кількість повторень
        })
        .ToList()

            });
            var productDto = _mapper.Map<IEnumerable<AttributeReadDto>>(attributeDto);



            return productDto;
        }
        public async Task<IEnumerable<BrandReadDto>> GetAllBrandsAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _repositoryManager.ProductRepository.GetAllBrandsAsync(cancellationToken);
            var brandDtos = categories.Select(p => new BrandReadDto
            {
                Id = p.Id,

                Lang = p.Lang,

                Title = p.Title,

                ImagePath = p.UploadedFiles.FilePath
                //  p.U.Select(attr => new AttributeProductDto
                // {
                //     AttributeId = attr.AttributeId,
                //     Value = attr.Value
                // }).ToList()
            });

            var productDto = _mapper.Map<IEnumerable<BrandReadDto>>(brandDtos);



            return productDto;
        }
        public async Task<IEnumerable<ProductReadDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _repositoryManager.ProductRepository.GetAllAsync(cancellationToken);

            var productDto = _mapper.Map<IEnumerable<ProductReadDto>>(categories);



            return productDto;
        }
        public async Task<IEnumerable<ProductCatalogDto>> FindAllProduct(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var categories = await _repositoryManager.ProductRepository.FindAllAsync(predicate, cancellationToken);

            var productDtos = categories.Select(p => new ProductCatalogDto
            {
                Id = p.Id,
                OriginId = p.OriginId,
                Lang = p.Lang,
                Status = p.Status,
                Price = p.Price,
                DiscountedPrice = p.DiscountedPrice,
                Name = p.Name,
                Popular = p.Popular,
                ImageId = p.ImageId,
                BrandId = p.BrandId,
                CreatedAt = p.CreatedAt,
                ImagePath = p.UploadedFiles?.FilePath ?? null,
                // UploadedFiles = p.UploadedFiles,
                Marks = p.Marks,
                Categories = p.Categories,
                Attributes = p.Attributes.Select(attr => new AttributeProductValDto
                {
                    AttributeId = attr.AttributeId,
                    Value = attr.Value
                }).ToList()
            });

            var productDto = _mapper.Map<IEnumerable<ProductCatalogDto>>(productDtos);

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
            if (productDto.ImageId != null)
            {
                productDto.ImagePath = product.UploadedFiles.FilePath;

            }
            if (product.ProductToUploadedFile.Count > 0)
            {
                productDto.Gallery = product.ProductToUploadedFile.Select(item => new UploadReadDto
                {
                    Id = item.UploadId,
                    ImagePath = item.UploadedFile.FilePath
                });
            }
            // userDto.UploadedFiles = String.Join(",", user.UploadedFiles.ToArray().Select(x => x.Name).ToArray());

            return productDto;
        }


    }

}
