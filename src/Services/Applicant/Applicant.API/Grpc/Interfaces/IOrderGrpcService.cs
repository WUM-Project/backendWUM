using GrpcExam;
using GrpcOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Applicant.API.Grpc.Interfaces
{
    public interface IOrderGrpcService
    {
         public OrderResponse GetUserOrders(string userId);
    }
}
