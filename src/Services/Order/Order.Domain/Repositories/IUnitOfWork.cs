using System;
using System.Threading;
using System.Threading.Tasks;


namespace Order.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
