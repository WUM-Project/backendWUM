using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Catalog.API.Application.Contracts.Dtos.CategoryDtos;
using Catalog.Domain.Entities;
using System.Linq.Expressions;

namespace Catalog.API.Application.Services.Interfaces
{
    public interface IUploadService
    {
       
    
        Task<UploadedFiles> CreateAsync(UploadedFiles file, CancellationToken cancellationToken = default);
      
    }
}
