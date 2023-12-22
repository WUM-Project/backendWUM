using System;
using System.Linq;
using Order.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Order.Infrastructure
{
    public static class OrderDbContextSeed
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProduction)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<OrderDbContext>(), isProduction);
            }
        }

        private static void SeedData(OrderDbContext context, bool isProduction)
        {
            
        }

    }
}
