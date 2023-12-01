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
           
            var products = await _dbContext.Products.Include(d => d.UploadedFiles)
        .Where(predicate)
        .ToListAsync(cancellationToken);

    foreach (var product in products)
    {
        // Підєднати залежності для кожного продукту
        await _dbContext.Entry(product)
            .Collection(d => d.Categories)
            .LoadAsync(cancellationToken);

        await _dbContext.Entry(product)
            .Collection(d => d.Marks)
            .LoadAsync(cancellationToken);
             // Перевірити, чи є об'єкт marks і mark, і встановити mark, якщо вони не null
 
 if (product.Marks != null)
    {
        foreach (var mark in product.Marks)
        {
            if (mark != null)
            {
                mark.Product = null;
                // Замініть цей блок коду залежно від вашої логіки створення об'єкта mark за його ідентифікатором markId
                mark.Mark = await _dbContext.Marks
                    .Where(m => m.Id == mark.MarkId)
                    .Select(m => new Mark
                    {
                        // Додайте поля, які вам потрібні
                        Id = m.Id,
                        Title = m.Title,
                        Color = m.Color,
                        // і так далі
                    })
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
 if (product.Categories != null)
    {
        foreach (var category in product.Categories)
        {
            if (category != null)
            {
              
                // Замініть цей блок коду залежно від вашої логіки створення об'єкта mark за його ідентифікатором markId
                category.Category = await _dbContext.Categories
                    .Where(m => m.Id == category.CategoryId)
                    .Select(m => new Category
                    {
                        // Додайте поля, які вам потрібні
                        Id = m.Id,
                        Title = m.Title,
                        Lang = m.Lang,
                        ParentId = m.ParentId
                        // і так далі
                    })
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
        // Додати інші пов'язані колекції за необхідності
    }
//     // Серіалізувати об'єкти, використовуючи параметр ReferenceHandler.Preserve
// var json = JsonSerializer.Serialize(products, new JsonSerializerOptions
// {
//     ReferenceHandler = ReferenceHandler.Preserve,
//     WriteIndented = true // Цей параметр додає відступи для зручності читання JSON
// });
               return products;
        }
public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken = default)
{
    var product = await _dbContext.Products
        .Include(d => d.UploadedFiles)
        .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

    if (product != null)
    {
        // Explicitly load the related collections
        await _dbContext.Entry(product)
            .Collection(d => d.Categories)
            .LoadAsync(cancellationToken);

        await _dbContext.Entry(product)
            .Collection(d => d.Marks)
            .LoadAsync(cancellationToken);

        // Add other related collections as needed
    }


    return product;
}
    //     public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    //     {
    //          var product = await _dbContext.Products.Include(d => d.UploadedFiles).Include(d => d.Categories).Include(d => d.Marks).FirstOrDefaultAsync(e => e.Id == id);


    //         // return product;
    //     //      var product = await _dbContext.Products
    //     // .Where(e => e.Id == id)
    //     // .Select(p => new Product
    //     // {
    //     //     Id = p.Id,
    //     //     OriginId = p.OriginId,
    //     //     Lang = p.Lang,
    //     //     Status = p.Status,
    //     //     // ... (include other properties you need)

    //     //     UploadedFiles = new UploadedFiles
    //     //     {
    //     //         Id = p.UploadedFiles.Id,
    //     //         Name = p.UploadedFiles.Name,
    //     //        FilePath = p.UploadedFiles.FilePath

             
    //     //     },
    //     //     Categories = new Category
    //     //     {
    //     //         Id = p.
    //     //         Title = p.UploadedFiles.Name,
    //     //        FilePath = p.UploadedFiles.FilePath

             
    //     //     },

    //     //     // Exclude other properties like Marks, Attributes, Categories, etc.

    //     // })
    //     // .FirstOrDefaultAsync(cancellationToken);
      
    //   //current
    //     // var product = await _dbContext.Products
      
    //     // .Where(e => e.Id == id)
    //     // .Select(p => new Product
    //     // {
    //     //     Id = p.Id,
    //     //     OriginId = p.OriginId,
    //     //     Lang = p.Lang,
    //     //     Status = p.Status,
    //     //     // ... (include other properties you need)

    //     //     UploadedFiles = new UploadedFiles
    //     //     {
    //     //         Id = p.UploadedFiles.Id,
    //     //         Name = p.UploadedFiles.Name,
    //     //         FilePath = p.UploadedFiles.FilePath
    //     //     },
            
          

    //     //     // Exclude other properties like Marks, Attributes, Categories, etc.

    //     // })
    //     // .FirstOrDefaultAsync(cancellationToken);
    //     return product;
    //     }
        
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
