using System;
using AutoMapper;
using Order.Domain.Entities;
using Order.Api.Application.Contracts.AddressItemDtos;

namespace Order.Api.Application.Contracts.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            //Source -> Target
            CreateMap<Address, AddressReadDto>();
         
            CreateMap<AddressCreateDto, Address>();
          
        }
    }
}
