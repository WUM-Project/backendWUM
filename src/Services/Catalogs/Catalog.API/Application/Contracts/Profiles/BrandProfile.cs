using System;
using AutoMapper;
using GrpcCatalog;
using Catalog.Domain.Entities;
using Catalog.API.Application.Contracts.Dtos.BrandDtos;

namespace Catalog.API.Application.Contracts.Profiles
{

    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            // Source -> Targer
            CreateMap<Brand, BrandReadDto>();
            CreateMap<BrandReadDto, Brand>();
         
          
        }

    }
}
