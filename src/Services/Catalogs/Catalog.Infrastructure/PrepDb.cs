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

            if (!context.Categories.Any())
            {
                Console.WriteLine("\n--> Seeding Data... \n");

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
                    OriginId = 3,
                    ParentId = 4,
                    Status = 2,
                    Position= 1,
                    //CreatedAt = new DateTimeOffset(DateTime.Now),
                    //UpdatedAt = new DateTimeOffset(DateTime.Now),
                    // Roles = new List<Role>() { adminRole, managerRole }
                };
               
                context.Categories.Add(category5);
                context.Categories.Add(category6);


                //Console.WriteLine($"--->> User1: {user1.Password} ") ;

                //context.UserExams.Add(new UserExams() { User = user1, ExamId = 1 });
                // context.Users.Add(user2);
                // context.Users.Add(user3);
                // context.Users.Add(user4);
                // context.Users.Add(user5);
                // context.Users.Add(user6);
                // context.Users.Add(user7);
                // context.Users.Add(user8);
                // context.Users.Add(user9);
                // context.Users.Add(user10);
                // context.Users.Add(user11);

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("\n--> We already have data\n");
            }
        }
    }
}
