using System;
using AutoMapper;
using Order.Domain.Entities;
using Order.Api.Application.Contracts.OrderItemDtos;

namespace Order.Api.Application.Contracts.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            //Source -> Target
            CreateMap<Orders, OrderReadDto>();
         
            CreateMap<OrderCreateDto, Orders>();
            CreateMap<ExamItemUpdateDto, Orders>();
            CreateMap<OrderUpdateCreateDto, Orders>();
        }
    }
}
