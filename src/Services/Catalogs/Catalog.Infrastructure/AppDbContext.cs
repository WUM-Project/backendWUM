﻿using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure
{
    public class AppDbContext : DbContext
    {
      
         public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
          
            
            Database.EnsureCreated();
        }
         public DbSet<ProductToMark> ProductToMarks { get; set; }
        public DbSet<ProductToCategory> ProductToCategories { get; set; }
        public DbSet<ProductToAttribute> ProductToAttributes { get; set; }
        public DbSet<Catalog.Domain.Entities.Attribute> Attributes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Product> Products { get; set; }
     

        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.Entity<ProductToMark>().ToTable("ProductToMark");
            builder.Entity<Product>().HasMany(x => x.Marks).WithOne(x => x.Product).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ProductToMark>().HasKey(sc => new { sc.ProductId, sc.MarkId });
            builder.Entity<ProductToCategory>().HasKey(sc => new { sc.ProductId, sc.CategoryId });

             builder.Entity<ProductToMark>()
                 .HasOne(ptc => ptc.Mark)
            .WithMany(c => c.Products)
            .HasForeignKey(ptc => ptc.MarkId).HasPrincipalKey(b => b.Id);
             
             builder.Entity<ProductToMark>()
            .HasKey(ptc => new { ptc.ProductId, ptc.MarkId });

             builder.Entity<ProductToMark>()
                 .HasOne(ptc => ptc.Product)
                 .WithMany(p => p.Marks)
                 .HasForeignKey(ptc => ptc.ProductId).HasPrincipalKey(b => b.Id);
     
            //  builder.Entity<ProductToCategory>()
            //      .HasOne(ptc => ptc.Category)
            // .WithMany(c => c.Products)
            // .HasForeignKey(ptc => ptc.CategoryId).HasPrincipalKey(b => b.Id);
             
            builder.Entity<ProductToAttribute>().HasKey(sc => new { sc.ProductId, sc.AttributeId });

            base.OnModelCreating(builder);
        }
    }
}
