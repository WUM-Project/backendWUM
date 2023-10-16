using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Catalog.API.Application.Contracts.Dtos.CategoryDtos;
using Catalog.Domain.Entities;
using System.Linq.Expressions;

namespace Catalog.API.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryReadDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<CategoryReadDto>> GetAllChild(int ParentId,CancellationToken cancellationToken = default);
        // Task<IList<Category>> BuildTree( IEnumerable<Category> source);
        // Task AddChildren(Category node, IDictionary<int, List<Category>> source);
       
      
    }
}
