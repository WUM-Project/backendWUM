using Applicant.API.Grpc.Interfaces;
using Grpc.Net.Client;

using GrpcOrder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Applicant.API.Grpc
{
    public class OrderGrpcService : IOrderGrpcService
    {
        private readonly ILogger<OrderGrpcService> _logger;
        private readonly IConfiguration _configuration;
        private GrpcChannel channel;
        private OrderGrpc.OrderGrpcClient client;

        public OrderGrpcService(ILogger<OrderGrpcService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            channel = GrpcChannel.ForAddress(_configuration["GrpcExamSettings:ExamUrl"]);
            client = new OrderGrpc.OrderGrpcClient(channel);
        }



        public OrderResponse GetUserOrders(string IdUser)
        {
            Console.WriteLine($"---> calling Exam GRPC Service: {_configuration["GrpcExamSettings:ExamUrl"]}");

            try
            {
                var request = new OrderRequest() { UserId = IdUser };

                return client.GetUserOrders(request);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"---> Could not call Grpc Server: {ex.Message}");
                return null;
            }
        }
    }
}
