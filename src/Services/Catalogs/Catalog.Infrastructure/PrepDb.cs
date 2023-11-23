using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using Catalog.Domain.Entities;
using Catalog.Infrastructure;

namespace Catalog.Infrasructure
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            //if (isProd)
            //{
            //    Console.WriteLine("\n---> Attempting to apply migrations...\n");

            //    try
            //    {
            //        context.Database.Migrate();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"\n---> Could not run migrations: {ex.Message}\n");
            //    }
            //}


            // if (!context.Roles.Any())
            // {

            //     List<Role> roles = new List<Role>();

            //     foreach (var item in Enum.GetValues(typeof(UserRoles)))
            //     {
            //         roles.Add(new Role()
            //         {
            //             Name = item.ToString(),
            //         });
            //     }

            //     context.Roles.AddRange(roles);
            //     context.SaveChanges();
            // }
  if (!context.Marks.Any())
            {
                Console.WriteLine("\n--> Seeding Marks Data... \n");

                // var hasher = new PasswordHasher<User>();


            
                var mark1 = new Mark
                {
                    Title = "Новинка",
                    Lang = "uk",
                    OriginId = 0,
                   Color="942C2C",
                    Status = 2,
                    Position= 1,
                 
                  
                };
                  var mark2 = new Mark
                {
                    Title = "Новинка",
                    Lang = "ru",
                    OriginId = 1,
                   Color="942C2C",
                    Status = 2,
                    Position= 1,
                 
                  
                };
              
                context.Marks.Add(mark1);
                context.Marks.Add(mark2);

                  var mark3 = new Mark
                {
                    Title = "Хіт",
                    Lang = "uk",
                    OriginId = 0,
                   Color="942C2C",
                    Status = 2,
                    Position= 1,
                 
                  
                };
                  var mark4 = new Mark
                {
                    Title = "Хіт",
                    Lang = "ru",
                    OriginId = 3,
                   Color="942C2C",
                    Status = 2,
                    Position= 1,
                 
                  
                };
              
                context.Marks.Add(mark3);
                context.Marks.Add(mark4);
                  var mark5 = new Mark
                {
                    Title = "Акційне",
                    Lang = "uk",
                    OriginId = 0,
                   Color="942C2C",
                    Status = 2,
                    Position= 1,
                 
                  
                };
                  var mark6 = new Mark
                {
                    Title = "Акційне",
                    Lang = "ru",
                    OriginId = 5,
                   Color="942C2C",
                    Status = 2,
                    Position= 1,
                 
                  
                };
              
                context.Marks.Add(mark5);
                context.Marks.Add(mark6);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("\n--> We already have mark data\n");
            }
  if (!context.Attributes.Any())
            {
                Console.WriteLine("\n--> Seeding Attributes Data... \n");

                // var hasher = new PasswordHasher<User>();


            
                var attribute1 = new Domain.Entities.Attribute
                {
                    Title = "SSD",
                    Lang = "uk",
                    OriginId = 0,
                    ShortTitle = "shorttitle",
                    UnitOfMeasurement= "gb",
                    Status = 2,
                    Position= 1,
                    GroupAttr=1
                  
                };
                var attribute2 =  new Domain.Entities.Attribute
                {
                    Title = "SSD",
                    Lang = "ru",
                    OriginId = 1,
                  GroupAttr=1,
                    Status = 2,
                    Position= 1,
                   
                };
              
                context.Attributes.Add(attribute1);
                context.Attributes.Add(attribute2);

                  var attribute3 = new Domain.Entities.Attribute
                {
                    Title = "VideoCard",
                    Lang = "uk",
                    OriginId = 0,
                    ShortTitle = "shorttitle",
                
                    GroupAttr=2,
                    Status = 2,
                    Position= 1,
                  
                };
                var attribute4 =  new Domain.Entities.Attribute
                {
                    Title = "VideoCard",
                    Lang = "ru",
                    OriginId = 3,
                  GroupAttr=2,
                    Status = 2,
                    Position= 1,
                   
                };
              
                context.Attributes.Add(attribute3);
                context.Attributes.Add(attribute4);
                  var attribute5 = new Domain.Entities.Attribute
                {
                    Title = "Procesor",
                    Lang = "uk",
                    OriginId = 0,
                    ShortTitle = "shorttitle",
                   
                    Status = 2,
                    GroupAttr=3,
                    Position= 1,
                  
                };
                var attribute6 =  new Domain.Entities.Attribute
                {
                    Title = "Procesor",
                    Lang = "ru",
                    OriginId = 5,
                  GroupAttr=3,
                    Status = 2,
                    Position= 1,
                   
                };
              
                context.Attributes.Add(attribute5);
                context.Attributes.Add(attribute6);

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("\n--> We already have attribute data\n");
            }
            if (!context.Categories.Any())
            {
                Console.WriteLine("\n--> Seeding Categories Data... \n");

                // var hasher = new PasswordHasher<User>();


            
                var category1 = new Category
                {
                    Title = "Товари для дому",
                    Lang = "uk",
                    OriginId = 0,
                    ParentId = 0,
                    Status = 2,
                    Position= 1,
                    //CreatedAt = new DateTimeOffset(DateTime.Now),
                    //UpdatedAt = new DateTimeOffset(DateTime.Now),
                    // Roles = new List<Role>() { adminRole, managerRole }
                };
                var category2 = new Category
                {
                    Title = "Товари для дому",
                    Lang = "ru",
                    OriginId = 1,
                    ParentId = 0,
                    Status = 2,
                    Position= 1,
                    //CreatedAt = new DateTimeOffset(DateTime.Now),
                    //UpdatedAt = new DateTimeOffset(DateTime.Now),
                    // Roles = new List<Role>() { adminRole, managerRole }
                };
              
                context.Categories.Add(category1);
                context.Categories.Add(category2);

                //Add Admin 
                
                var category3 = new Category
                {
                    Title = "Комп'ютери та ноутбуки",
                    Lang = "uk",
                    OriginId = 0,
                    ParentId = 0,
                    Status = 2,
                    Position= 1,
                    //CreatedAt = new DateTimeOffset(DateTime.Now),
                    //UpdatedAt = new DateTimeOffset(DateTime.Now),
                    // Roles = new List<Role>() { adminRole, managerRole }
                };
                var category4 = new Category
                {
                    Title = "Комп'ютери та ноутбуки",
                    Lang = "ru",
                    OriginId = 3,
                    ParentId = 0,
                    Status = 2,
                    Position= 1,
                    //CreatedAt = new DateTimeOffset(DateTime.Now),
                    //UpdatedAt = new DateTimeOffset(DateTime.Now),
                    // Roles = new List<Role>() { adminRole, managerRole }
                };
               
                context.Categories.Add(category3);
                context.Categories.Add(category4);
               
                var category5 = new Category
                {   
                    Title = "Смартфони, ТВ і електроніка",
                    Lang = "uk",
                    OriginId = 0,
                    ParentId = 0,
                    Status = 2,
                    Position= 1,
                    //CreatedAt = new DateTimeOffset(DateTime.Now),
                    //UpdatedAt = new DateTimeOffset(DateTime.Now),
                    // Roles = new List<Role>() { adminRole, managerRole }
                };
                var category6 = new Category
                {
                    Title = "Смартфони, ТВ і електроніка",
                    Lang = "ru",
                    OriginId = 5,
                    ParentId = 4,
                    Status = 2,
                    Position= 1,
                    //CreatedAt = new DateTimeOffset(DateTime.Now),
                    //UpdatedAt = new DateTimeOffset(DateTime.Now),
                    // Roles = new List<Role>() { adminRole, managerRole }
                };
               
                context.Categories.Add(category5);
                context.Categories.Add(category6);

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("\n--> We already have Category data\n");
            }


            if (!context.Products.Any())
            {
                Console.WriteLine("\n--> Seeding Products Data... \n");

                // var hasher = new PasswordHasher<User>();


            
                var product1 = new Product
                {
                    Name = "Ноутбук Acer Nitro 5 AN515-46-R1SB Black",
                    Description = "Домінуйте в іграх завдяки поєднаною потіжністю AMD Ryzen серії 6000",
                    ShortDescription = "Новинка",
                    Sku = "394195905",
                    Price = 69229,
                    DiscountedPrice = 72699,
                    Quantity = 100,
                    Lang = "uk",
                    OriginId = 0,
                 
                    Status = 2,
                    Position= 1,
                 
                  
                };
                var product2 = new Product
                {
                    Name = "Ноутбук Acer Nitro 5 AN515-46-R1SB Black",
                    Description = "Домінуйте в іграх завдяки поєднаною потіжністю AMD Ryzen серії 6000",
                    ShortDescription = "Новинка",
                    Sku = "394195905",
                    Price = 69229,
                    DiscountedPrice = 72699,
                    Quantity = 100,
                    Lang = "ru",
                    OriginId = 1,
                 
                    Status = 2,
                    Position= 1,
                 
                  
                };
              
              
                context.Products.Add(product1);
                context.Products.Add(product2);
              
                var product3 = new Product
                {
                    Name = "Ноутбук Lenovo IdeaPad 3 15IAU7 (82RK00TWRA) Arctic Grey ",
                    Description = "Компактний, але при цьому високопродуктивний ноутбук Зберігайте підключення до мережі інтернет у будь-якому місці за допомогою надзвичайно тонкого ноутбука IdeaPad 3 (7th Gen, 15, Intel). Він завантажується за лічені секунди завдяки функції Flip to Start, для увімкнення якої досить підняти кришку ноутбука, та оснащений надефективним процесором Intel, що дає змогу з легкістю працювати в багатозадачному режимі.",
                    ShortDescription = "Новинка",
                    Sku = "379981179",
                    Price = 27999,
                    DiscountedPrice = 21499,
                    Quantity = 100,
                    Lang = "uk",
                    OriginId = 0,
                 
                    Status = 2,
                    Position= 1,
                 
                  
                };
                var product4 = new Product
                {
                    Name = "Ноутбук Lenovo IdeaPad 3 15IAU7 (82RK00TWRA) Arctic Grey ",
                     Description = "Компактний, але при цьому високопродуктивний ноутбук Зберігайте підключення до мережі інтернет у будь-якому місці за допомогою надзвичайно тонкого ноутбука IdeaPad 3 (7th Gen, 15, Intel). Він завантажується за лічені секунди завдяки функції Flip to Start, для увімкнення якої досить підняти кришку ноутбука, та оснащений надефективним процесором Intel, що дає змогу з легкістю працювати в багатозадачному режимі.",
                    ShortDescription = "Новинка",
                    Sku = "379981179",
                    Price = 27999,
                    DiscountedPrice = 21499,
                    Quantity = 100,
                    Lang = "ru",
                    OriginId = 3,
                    Status = 2,
                    Position= 1,
                 
                  
                };
              
              
                context.Products.Add(product3);
                context.Products.Add(product4);
                var product5 = new Product
                {
                    Name = "Ноутбук Acer Predator Helios 300 PH315-55-74TY (NH.QGNEU.005) Abyssal Black",
                    Description = "дягніть екіпірування, пристебніть ремені — і нехай Helios прокладе шлях. Цей ігровий ноутбук обладнаний чудовою технологією охолодження, неймовірно швидким дисплеєм і рядом функцій для покращення продуктивності, тому стане вашим путівником для насолоди від ігор. За підтримки процесора Intel Core 12-го покоління та відеокарти NVIDIA GeForce RTX.  ",
                    ShortDescription = "Новинка",
                    Sku = "379981179",
                    Price = 69999,
                    DiscountedPrice = 52999,
                    Quantity = 100,
                    Lang = "uk",
                    OriginId = 0,
                 
                    Status = 2,
                    Position= 1,
                 
                  
                };
                var product6 = new Product
                {
                    Name = "Ноутбук Acer Predator Helios 300 PH315-55-74TY (NH.QGNEU.005) Abyssal Black",
                     Description = "дягніть екіпірування, пристебніть ремені — і нехай Helios прокладе шлях. Цей ігровий ноутбук обладнаний чудовою технологією охолодження, неймовірно швидким дисплеєм і рядом функцій для покращення продуктивності, тому стане вашим путівником для насолоди від ігор. За підтримки процесора Intel Core 12-го покоління та відеокарти NVIDIA GeForce RTX.  ",
                    ShortDescription = "Новинка",
                    Sku = "379981179",
                    Price = 69999,
                    DiscountedPrice = 52999,
                    Quantity = 100,
                    Lang = "ru",
                    OriginId = 3,
                    Status = 2,
                    Position= 1,
                 
                  
                };
              
              
                context.Products.Add(product5);
                context.Products.Add(product6);
              

             
              
               
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("\n--> We already have Products data\n");
            }
            if (!context.ProductToCategories.Any())
            {
                Console.WriteLine("\n--> Seeding ProductToCategories Data... \n");

                // var hasher = new PasswordHasher<User>();


            
                var productTocategory = new ProductToCategory
                {
                   
                 ProductId= 1,
                 CategoryId=3,
                  
                };
                var productTocategory2 = new ProductToCategory
                {
                   
                 ProductId= 2,
                 CategoryId=4,
                  
                };
                
              
              
                context.ProductToCategories.Add(productTocategory);
                context.ProductToCategories.Add(productTocategory2);
                var productTocategory3 = new ProductToCategory
                {
                   
                 ProductId= 3,
                 CategoryId=3,
                  
                };
                var productTocategory4 = new ProductToCategory
                {
                   
                 ProductId= 4,
                 CategoryId=4,
                  
                };
                
              
              
                context.ProductToCategories.Add(productTocategory3);
                context.ProductToCategories.Add(productTocategory4);
                var productTocategory5 = new ProductToCategory
                {
                   
                 ProductId= 5,
                 CategoryId=3,
                  
                };
                var productTocategory6 = new ProductToCategory
                {
                   
                 ProductId= 6,
                 CategoryId=4,
                  
                };
                
              
              
                context.ProductToCategories.Add(productTocategory5);
                context.ProductToCategories.Add(productTocategory6);
                
              
              

             
              
               
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("\n--> We already have ProductToCategories data\n");
            }
            // if (!context.ProductToAttributes.Any())
            // {
            //     Console.WriteLine("\n--> Seeding ProductToAttributes Data... \n");

            //     // var hasher = new PasswordHasher<User>();


            
            //     var product1Toattribute = new ProductToAttribute
            //     {
                   
            //      ProductId= 1,
            //      Value="1TB",
            //      AttributeId=1,
                  
            //     };
            //     var product1Toattribute2 = new ProductToAttribute
            //     {
                   
            //      ProductId= 2,
            //      Value="1TB",
            //      AttributeId=2,
                  
            //     };
                
              
              
            //     context.ProductToAttributes.Add(product1Toattribute);
            //     context.ProductToAttributes.Add(product1Toattribute2);
            //     var product1Toattribute3 = new ProductToAttribute
            //     {
                   
            //      ProductId= 1,
            //      Value="GeForse RTX 3070 TI",
            //      AttributeId=3,
                  
            //     };
            //     var product1Toattribute4 = new ProductToAttribute
            //     {
                   
            //      ProductId= 2,
            //      Value="GeForse RTX 3070 TI",
            //      AttributeId=4,
                  
            //     };
                
              
              
            //     context.ProductToAttributes.Add(product1Toattribute3);
            //     context.ProductToAttributes.Add(product1Toattribute4);
           
            //     var product1Toattribute5 = new ProductToAttribute
            //     {
                   
            //      ProductId= 1,
            //      Value="Восьмиядерий AMD Ryzen 7 6800H (3.2-4.7 Гц)",
            //      AttributeId=5,
                  
            //     };
            //     var product1Toattribute6 = new ProductToAttribute
            //     {
                   
            //      ProductId= 2,
            //      Value="Восьмиядерий AMD Ryzen 7 6800H (3.2-4.7 Гц)",
            //      AttributeId=6,
                  
            //     };
                
              
              
            //     context.ProductToAttributes.Add(product1Toattribute5);
            //     context.ProductToAttributes.Add(product1Toattribute6);
           
                
            //     var product2Toattribute = new ProductToAttribute
            //     {
                   
            //      ProductId= 3,
            //      Value="512 ГБ",
            //      AttributeId=1,
                  
            //     };
            //     var product2Toattribute2 = new ProductToAttribute
            //     {
                   
            //      ProductId= 4,
            //      Value="512 ГБ",
            //      AttributeId=2,
                  
            //     };
                
              
              
            //     context.ProductToAttributes.Add(product2Toattribute);
            //     context.ProductToAttributes.Add(product2Toattribute2);
            //     var product2Toattribute3 = new ProductToAttribute
            //     {
                   
            //      ProductId= 3,
            //      Value="Інтегрована Iris Xe Graphics",
            //      AttributeId=3,
                  
            //     };
            //     var product2Toattribute4 = new ProductToAttribute
            //     {
                   
            //      ProductId= 4,
            //      Value="Інтегрована Iris Xe Graphics",
            //      AttributeId=4,
                  
            //     };
                
              
              
            //     context.ProductToAttributes.Add(product2Toattribute3);
            //     context.ProductToAttributes.Add(product2Toattribute4);
           
            //     var product2Toattribute5 = new ProductToAttribute
            //     {
                   
            //      ProductId= 3,
            //      Value="Десятиядерний Intel Core i5-1235U (0.9 - 4.4 ГГц)",
            //      AttributeId=5,
                  
            //     };
            //     var product2Toattribute6 = new ProductToAttribute
            //     {
                   
            //      ProductId= 4,
            //      Value="Десятиядерний Intel Core i5-1235U (0.9 - 4.4 ГГц)",
            //      AttributeId=6,
                  
            //     };
                
              
              
            //     context.ProductToAttributes.Add(product2Toattribute5);
            //     context.ProductToAttributes.Add(product2Toattribute6);
              
            //     var product3Toattribute = new ProductToAttribute
            //     {
                   
            //      ProductId= 5,
            //      Value="512 ГБ",
            //      AttributeId=1,
                  
            //     };
            //     var product3Toattribute2 = new ProductToAttribute
            //     {
                   
            //      ProductId= 6,
            //      Value="512 ГБ",
            //      AttributeId=2,
                  
            //     };
                
              
              
            //     context.ProductToAttributes.Add(product3Toattribute);
            //     context.ProductToAttributes.Add(product3Toattribute2);
            //     var product3Toattribute3 = new ProductToAttribute
            //     {
                   
            //      ProductId= 5,
            //      Value="GeForce RTX 3070",
            //      AttributeId=3,
                  
            //     };
            //     var product3Toattribute4 = new ProductToAttribute
            //     {
                   
            //      ProductId= 6,
            //      Value="GeForce RTX 3070",
            //      AttributeId=4,
                  
            //     };
                
              
              
            //     context.ProductToAttributes.Add(product3Toattribute3);
            //     context.ProductToAttributes.Add(product3Toattribute4);
           
            //     var product3Toattribute5 = new ProductToAttribute
            //     {
                   
            //      ProductId= 5,
            //      Value="Чотирнадцятиядерний Intel Core i7-12700H (2.3 - 4.7 ГГц)",
            //      AttributeId=5,
                  
            //     };
            //     var product3Toattribute6 = new ProductToAttribute
            //     {
                   
            //      ProductId= 6,
            //      Value="Чотирнадцятиядерний Intel Core i7-12700H (2.3 - 4.7 ГГц)",
            //      AttributeId=6,
                  
            //     };
                
              
              
            //     context.ProductToAttributes.Add(product3Toattribute5);
            //     context.ProductToAttributes.Add(product3Toattribute6);
           
                
              
              

             
              
               
            //     context.SaveChanges();
            // }
            // else
            // {
            //     Console.WriteLine("\n--> We already have ProductToAttributes data\n");
            // }
             if (!context.ProductToMarks.Any())
            {
                Console.WriteLine("\n--> Seeding ProductToMarks Data... \n");

                // var hasher = new PasswordHasher<User>();


            
                var productTomark = new ProductToMark
                {
                   
                 ProductId= 1,
                 MarkId=1,
                  
                };
                var productTomark2 = new ProductToMark
                {
                   
                 ProductId= 2,
                 MarkId=2,
                  
                };
                
              
              
                context.ProductToMarks.Add(productTomark);
                context.ProductToMarks.Add(productTomark2);
                var productTomark3 = new ProductToMark
                {
                   
                 ProductId= 3,
                 MarkId=3,
                  
                };
                var productTomark4 = new ProductToMark
                {
                   
                 ProductId= 4,
                 MarkId=4,
                  
                };
                
              
              
                context.ProductToMarks.Add(productTomark3);
                context.ProductToMarks.Add(productTomark4);
              
              
              

             
              
               
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("\n--> We already have ProductToMarks data\n");
            }
        }
    }
}
