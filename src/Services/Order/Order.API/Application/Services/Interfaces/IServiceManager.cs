using System;

namespace Order.Api.Application.Services.Interfaces
{
    public interface IServiceManager
    {
        IOrderService OrderService { get; }
        // IExamQuestionService ExamQuestionService { get; }
    }
}
