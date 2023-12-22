using System;
using AutoMapper;
using Order.Domain.Repositories;
using Order.Api.Application.Services.Interfaces;
using Order.Api.Grpc;
using Order.Api.Grpc.Interfaces;

namespace Order.Api.Application.Services
{
    // Our service instances are only going to be created when we access them for the first time,
    // and not before that.
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IOrderService> _lazyOrderService;
        // private readonly Lazy<IExamQuestionService> _lazyExamQuestionService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, IApplicantGrpcService applicantGprcService)
        {
            _lazyOrderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager, mapper, applicantGprcService));
            // _lazyExamQuestionService = new Lazy<IExamQuestionService>(() => new ExamQuestionService(repositoryManager, mapper, reportGrpcService, questionGrpcService));
        }


        public IOrderService OrderService => _lazyOrderService.Value;
        // public IExamQuestionService ExamQuestionService => _lazyExamQuestionService.Value;
    }
}
