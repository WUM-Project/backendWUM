using System;
using System.Net;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Catalog.API.Application.Exceptions;
using Catalog.API.Application.Configurations;
using Catalog.API.Application.Services.Interfaces;
using Catalog.API.Application.Contracts.Dtos.CategoryDtos;

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Catalog.API.Grpc;
using System.Linq.Expressions;
using Grpc.Net.Client;
//using GrpcExam;
using Microsoft.Extensions.Configuration;
// using Catalog.API.Grpc.Interfaces;
using Catalog.API.Application.Contracts.Infrastructure;
using Catalog.API.Application.Models;

namespace Catalog.API.Application.Services
{
    internal sealed class UploadService : IUploadService
    {


        private readonly IMapper _mapper;
  
        private readonly IRepositoryManager _repositoryManager;

 public UploadService(IRepositoryManager repositoryManager, IMapper mapper
      )
        {
            _mapper = mapper;
         ;
            _repositoryManager = repositoryManager;
            // _reportGrpcService = reportGrpcService;
            // _examGrpcService = examGrpcService;
        }
    
 public async Task<UploadedFiles> CreateAsync(UploadedFiles files, CancellationToken cancellationToken = default)
        {

           

            _repositoryManager.UploadRepository.Insert(files);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

        

          

            return _mapper.Map<UploadedFiles>(files);
        }
    
    }

}
