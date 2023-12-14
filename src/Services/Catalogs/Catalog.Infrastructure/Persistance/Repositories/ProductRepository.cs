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
        
 
 if (product.Marks != null)
    {
        foreach (var mark in product.Marks)
        {
            if (mark != null)
            {
                mark.Product = null;
               
                mark.Mark = await _dbContext.Marks
                    .Where(m => m.Id == mark.MarkId)
                    .Select(m => new Mark
                    {
                      
                        Id = m.Id,
                        Title = m.Title,
                        Color = m.Color,
                       
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
              
                
                category.Category = await _dbContext.Categories
                    .Where(m => m.Id == category.CategoryId)
                    .Select(m => new Category
                    {
                      
                        Id = m.Id,
                        Title = m.Title,
                        Lang = m.Lang,
                        ParentId = m.ParentId
                   
                    })
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
        
    }

               return products;
        }
public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken = default)
{
    var product = await _dbContext.Products
        .Include(d => d.UploadedFiles)
        .FirstOrDefaultAsync(e => e.Id == id);

    if (product != null)
    {
         await _dbContext.Entry(product)
            .Collection(p => p.Attributes)
            .LoadAsync(cancellationToken);
   await _dbContext.Entry(product)
            .Collection(d => d.Categories)
            .LoadAsync(cancellationToken);

        await _dbContext.Entry(product)
            .Collection(d => d.Marks)
            .LoadAsync(cancellationToken);
    
 await _dbContext.Entry(product)
            .Collection(p => p.ProductToUploadedFile)
            .LoadAsync(cancellationToken);
   

      //Витяжка аттрибутів
         if (product.Attributes != null)
    {
        foreach (var item in product.Attributes)
        {
            if (item != null)
            {
                item.Product = null;
                
                item.Attribute = await _dbContext.Attributes
                    .Where(m => m.Id == item.AttributeId)
                    .Select(m => new Catalog.Domain.Entities.Attribute
                    {
                        
                        Id = m.Id,
                        Title = m.Title,
                        ShortTitle = m.ShortTitle,
                        UnitOfMeasurement = m.UnitOfMeasurement,
                        GroupAttr = m.GroupAttr,
                     
                    })
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
           //Витяжка позначок
         if (product.Marks != null)
    {
        foreach (var mark in product.Marks)
        {
            if (mark != null)
            {
                mark.Product = null;
                
                mark.Mark = await _dbContext.Marks
                    .Where(m => m.Id == mark.MarkId)
                    .Select(m => new Mark
                    {
                        
                        Id = m.Id,
                        Title = m.Title,
                        Color = m.Color,
                     
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
              
               
                category.Category = await _dbContext.Categories
                    .Where(m => m.Id == category.CategoryId)
                    .Select(m => new Category
                    {
                      
                        Id = m.Id,
                        Title = m.Title,
                        Lang = m.Lang,
                        ParentId = m.ParentId,
                        
                      
                    })
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
        // Add other related collections as needed
    if (product.ProductToUploadedFile != null)
    {
        foreach (var file in product.ProductToUploadedFile)
        {
            if (file.UploadId != null)
            {
               
              
                file.UploadedFile = await _dbContext.UploadedFile
                    .Where(m => m.Id == file.UploadId)
                    .Select(m => new UploadedFiles
                    {
                        
                        Id = m.Id,
                        FilePath = m.FilePath,
                        Name = m.Name,
                      
                    })
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
   
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
