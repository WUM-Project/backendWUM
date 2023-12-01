using System;
using AutoMapper;
using GrpcCatalog;
using Catalog.Domain.Entities;
using Catalog.API.Application.Contracts.Dtos.ProductDtos;

namespace Catalog.API.Application.Contracts.Profiles
{

    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            // Source -> Targer
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductReadDto, Product>();
            CreateMap<Product, ProductCatalogDto>();
            CreateMap<ProductCatalogDto, Product>();
          
        }

    }
}
