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
    internal sealed class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext; 
        }


     public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Categories
                .ToListAsync(cancellationToken);
        }
          public async Task<IEnumerable<Category>> FindAllAsync(Expression<Func<Category, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Categories.Where(predicate)
                .ToListAsync(cancellationToken);
        }
    }
    // public static IList<Category> BuildTree(this IEnumerable<Category> source)
    // {
    //     var groups = source.GroupBy(i => i.ParentId);

    //     var roots = groups.FirstOrDefault(g => g.Key.HasValue == false).ToList();

    //     if (roots.Count > 0)
    //     {
    //         var dict = groups.Where(g => g.Key.HasValue).ToDictionary(g => g.Key.Value, g => g.ToList());
    //         for (int i = 0; i < roots.Count; i++)
    //             AddChildren(roots[i], dict);
    //     }

    //     return roots;
    // }

    // private static void AddChildren(Category node, IDictionary<int, List<Category>> source)
    // {
    //     if (source.ContainsKey(node.Id))
    //     {
    //         node.Children = source[node.Id];
    //         for (int i = 0; i < node.Children.Count; i++)
    //             AddChildren(node.Children[i], source);
    //     }
    //     else
    //     {
    //         node.Children = new List<Category>();
    //     }
    // }

}
