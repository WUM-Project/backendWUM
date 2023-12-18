using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Catalog.Domain.Entities;
using System.Collections.Generic;


namespace Catalog.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Brand>> GetAllBrandsAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Catalog.Domain.Entities.Attribute>> GetAllAttributesAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetMinMaxPriceAsync(CancellationToken cancellationToken);
             Task<IEnumerable<Product>> FindAllAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default);
             Task<Product> GetByIdAsync(int id,CancellationToken cancellationToken = default);
       
    }
}
