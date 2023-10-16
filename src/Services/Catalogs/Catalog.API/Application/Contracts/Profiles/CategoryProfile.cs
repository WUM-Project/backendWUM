using System;
using AutoMapper;
using GrpcCatalog;
using Catalog.Domain.Entities;
using Catalog.API.Application.Contracts.Dtos.CategoryDtos;

namespace Catalog.API.Application.Contracts.Profiles
{

    public class CategoryProfiles : Profile
    {
        public CategoryProfiles()
        {
            // Source -> Targer
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryReadDto, Category>();
          
        }

    }
}
