using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Catalog.API.Application.Contracts.Dtos.ProductDtos;
using Catalog.Domain.Entities;
using System.Linq.Expressions;

namespace Catalog.API.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductReadDto>> GetAllAsync(CancellationToken cancellationToken = default);
        // Task<IEnumerable<ProductReadDto>> FindAllProduct(Expression<Func<Product, bool>> predicate,CancellationToken cancellationToken = default);
           Task<ProductReadDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ProductCatalogDto>> FindAllProduct(Expression<Func<Product, bool>> originalPredicate, CancellationToken cancellationToken);
    }
}
