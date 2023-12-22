using System;

using Grpc.Core;
using GrpcOrder;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Order.Api.Application.Services.Interfaces;
using System.Linq;
using Order.Domain.Repositories;
using Order.Api.Application.Contracts.OrderItemDtos;
using AutoMapper;
using Order.Api.Application.Services;

namespace Order.Api.Grpc
{
    // gRPC comment: regular method
    public class OrderGrpcService: OrderGrpc.OrderGrpcBase
    {
       

 private readonly IServiceManager _serviceManager;
        private readonly ILogger<OrderGrpcService> _logger;

        public OrderGrpcService(IServiceManager serviceManager, ILogger<OrderGrpcService> logger)
        {
            _serviceManager = serviceManager ?? throw new ArgumentNullException(nameof(serviceManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

     

     
public override async Task<OrderResponse> GetUserOrders(OrderRequest request, ServerCallContext context)
{
    //var exams = await _serviceManager.ExamItemService.GetAllByQuestionId(request.QuestionId);
    var orders = await _serviceManager.OrderService.GetAllUserOrderById(request.UserId);
    
    OrderResponse response = new OrderResponse();

    if (orders != null && orders.Count() > 0)
    {
        // response.UserId = request.UserId;
        // response.Exams.AddRange(orders.Select(x => x.Id));
           
        foreach (var order in orders)
        {
          
            var orderDataResponse = new OrderDataResponse
            {
                Id = order.Id,
                UserId = order.UserId,
                AddressId = order.AddressId,
                Status = order.Status,
                TotalPrice = order.TotalPrice,
                DeliveryType = order.DeliveryType,
                PayType = order.PayType,
                
            };

            foreach (var product in order.ProductsJson)
            {
                var productData = new ProductData
                {
                    Id = product.Id,
                    Name = product.Name,
                    Count = product.Count,
                    Price = product.Price,
                    DiscountedPrice = product.DiscountedPrice,
                    ImagePath = product.ImagePath
                };
                orderDataResponse.ProductsJson.Add(productData);
            }

            var address = order.Addresses;
            var addressData = new Addresses
            {
                Id = address.Id,
                Street = address.Street,
                Apartment = address.Apartment,
                House = address.House,
                District = address.District,
                City = address.City,
                Department = address.Department,
                FirstName = address.FirstName,
                LastName = address.LastName,
                FatherName = address.FatherName,
                Email = address.Email,
                Phone = address.Phone,
                SelfPickupPoint = address.SelfPickupPoint
            };
            orderDataResponse.Addresses = addressData;

            response.OrderResponses.Add(orderDataResponse);
        }

        return await Task.FromResult(response);
    }

    return await Task.FromResult(response);
}
     
    }
}
