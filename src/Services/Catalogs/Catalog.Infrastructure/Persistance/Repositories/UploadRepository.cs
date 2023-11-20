using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;

using Microsoft.EntityFrameworkCore;
using Catalog.Infrastructure;

namespace Catalog.Infrasructure.Persistance.Repositories
{
    internal sealed class UploadRepository : IUploadRepository
    {
        private readonly AppDbContext _dbContext;
        public UploadRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

    public void Insert(UploadedFiles file)
        {
            _dbContext.UploadedFile.Add(file);
        }
        public void Delete(UploadedFiles file)
        {
            _dbContext.UploadedFile.Remove(file);
        }
    public async Task<UploadedFiles> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
           return await _dbContext.UploadedFile
                .FirstOrDefaultAsync(x => x.Id == id);
        }

}
}
