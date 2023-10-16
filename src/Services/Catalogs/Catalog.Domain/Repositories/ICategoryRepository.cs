using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Catalog.Domain.Entities;
using System.Collections.Generic;


namespace Catalog.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken);
             Task<IEnumerable<Category>> FindAllAsync(Expression<Func<Category, bool>> predicate, CancellationToken cancellationToken = default);
        //  Task<IList<Category>> BuildTree( IEnumerable<Category> source);
        

    }
}
