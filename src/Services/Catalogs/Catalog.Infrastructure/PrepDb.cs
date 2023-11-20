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
                    Title = "Parent1",
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
                    Title = "Parent1",
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
                    Title = "Parent2",
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
                    Title = "Parent2",
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
                    Title = "Parent2",
                    Lang = "uk",
                    OriginId = 0,
                    ParentId = 3,
                    Status = 2,
                    Position= 1,
                    //CreatedAt = new DateTimeOffset(DateTime.Now),
                    //UpdatedAt = new DateTimeOffset(DateTime.Now),
                    // Roles = new List<Role>() { adminRole, managerRole }
                };
                var category6 = new Category
                {
                    Title = "Parent2",
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
        }
    }
}
