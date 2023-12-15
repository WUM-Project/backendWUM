using System;
using AutoMapper;
using GrpcCatalog;
using Catalog.Domain.Entities;
using Catalog.API.Application.Contracts.Dtos.AttributeDtos;

namespace Catalog.API.Application.Contracts.Profiles
{

    public class AttributeProfile : Profile
    {
        public AttributeProfile()
        {
            // Source -> Targer
            CreateMap<Catalog.Domain.Entities.Attribute, AttributeReadDto>();
            CreateMap<AttributeReadDto, Catalog.Domain.Entities.Attribute>();
            CreateMap<Catalog.Domain.Entities.Attribute, AttributeProductDto>();
            CreateMap<AttributeProductDto, Catalog.Domain.Entities.Attribute>();
          
        }

    }
}
