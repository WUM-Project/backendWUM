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

   

}
}
