using System;
using Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Order.Infrastructure
{
    public sealed class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

     
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Address> Address { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
           



         

            builder.Entity<Orders>()
          .HasOne(c => c.Address)
          .WithMany(uf => uf.Orders)
          .HasForeignKey(c => c.AddressId) // Assuming ImageId is the foreign key in Category
          .OnDelete(DeleteBehavior.Restrict); // Adjust the delete behavior as needed



        




            base.OnModelCreating(builder);
        }
        }
}
