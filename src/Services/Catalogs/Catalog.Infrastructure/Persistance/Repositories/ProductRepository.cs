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
    internal sealed class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext; 
        }


     public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
//             var products = await _dbContext.Products
//         .Select(p => new
//         {
//             Product = p,
//             Categories = p.Categories.Select(pc => pc.Category).ToList()
//         })
//         .ToListAsync();

//     // Access the products and their related categories
//     var productEntities = products?.Select(p => p.Product).ToList();
//     var categories = products?.SelectMany(p => p.Categories).ToList();
//  // You can include the categories in the Product entities if needed
//     foreach (var product in productEntities)
//     {
//         var productCategories = products?.FirstOrDefault(p => p.Product == product)?.Categories;
//         // product.Categories = productCategories?.ToList();;
//     }
   
//     return productEntities;
//      
        var products = await _dbContext.Products
        .Include(p => p.UploadedFiles)
        .ToListAsync(cancellationToken);

    return products.Select(p => new Product
    {
        Id = p.Id,
        OriginId = p.OriginId,
        Lang = p.Lang,
        Status = p.Status,
        Description = p.Description,
        ShortDescription = p.ShortDescription,
        Sku = p.Sku,
        Price = p.Price,
        DiscountedPrice = p.DiscountedPrice,
        Quantity = p.Quantity,
        Name = p.Name,
        ShortName = p.ShortName,
        Position = p.Position,
        Availability = p.Availability,
        Popular = p.Popular,
        ImageId = p.ImageId,
        CreatedAt = p.CreatedAt,
        UpdatedAt = p.UpdatedAt,
        UploadedFiles = p.UploadedFiles,
        Marks = p.Marks,
        Attributes = p.Attributes,
        Categories = p.Categories
    });
        //     return await _dbContext.Products
        // .Include(p => p.UploadedFiles)
        // .ToListAsync(cancellationToken);
        }
          public async Task<IEnumerable<Product>> FindAllAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Products.Where(predicate)
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
