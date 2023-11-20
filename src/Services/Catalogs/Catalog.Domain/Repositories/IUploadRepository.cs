using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Catalog.Domain.Entities;
using System.Collections.Generic;


namespace Catalog.Domain.Repositories
{
    public interface IUploadRepository
    {
        Task<UploadedFiles> GetByIdAsync(int id, CancellationToken cancellationToken = default);
         void Insert(UploadedFiles file);
         void Delete(UploadedFiles file);

    }
}
