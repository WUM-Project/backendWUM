using System;
using AutoMapper;
using GrpcCatalog;
using Catalog.Domain.Entities;
using Catalog.API.Application.Contracts.Dtos.UploadDtos;

namespace Catalog.API.Application.Contracts.Profiles
{

    public class UploadProfiles : Profile
    {
        public UploadProfiles()
        {
            // Source -> Targer
            // CreateMap<Product, ProductReadDto>();
             CreateMap<UploadedFiles, UploadReadDto>();
            // .ForMember(dest => dest.ProductToUploadedFiles, opt => opt.MapFrom(src => src.ProductToUploadedFile));
            CreateMap<UploadReadDto, UploadedFiles>();
     
          
        }

    }
}
