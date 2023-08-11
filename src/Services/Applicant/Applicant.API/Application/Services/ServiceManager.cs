using System;
using AutoMapper;
using Microsoft.Extensions.Options;

using Applicant.API.Grpc;
using Applicant.Domain.Repositories;
using Applicant.API.Application.Services.Interfaces;
using Applicant.API.Application.Configurations;
using Microsoft.Extensions.Configuration;
using Applicant.API.Grpc.Interfaces;
using Applicant.API.Application.Contracts.Infrastructure;

namespace Applicant.API.Application.Services
{
    public class ServiceManager : IServiceManager
    {   
        
        private readonly Lazy<IAccessCodeService> _lazyAccessCodeService;
        private readonly Lazy<IUserService> _lazyUserService;
//  IReportGrpcService reportGrpcService, IExamGrpcService examGrpcService,
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, 
            IOptionsMonitor<JwtConfig> optionsMonitor, IEmailService emailService)
        {
            _lazyAccessCodeService = new Lazy<IAccessCodeService>(() => new AccessCodeService(repositoryManager, mapper, optionsMonitor,emailService));
            _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper,  emailService));
            // reportGrpcService, examGrpcService,
        }

        public IAccessCodeService AccessCodeService => _lazyAccessCodeService.Value;
        public IUserService UserService => _lazyUserService.Value;
    }

}