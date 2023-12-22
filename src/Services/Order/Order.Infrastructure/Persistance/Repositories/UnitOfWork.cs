using System;
using System.Threading;
using System.Threading.Tasks;
using Order.Domain.Repositories;


namespace Order.Infrastructure.Persistance.Repositories
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly OrderDbContext _dbContext;

        public UnitOfWork(OrderDbContext dbContext) => _dbContext = dbContext;

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            _dbContext.SaveChangesAsync(cancellationToken);
    }
}
