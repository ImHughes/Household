using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Household.Models;

namespace Household.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Household.Models.Products> Products { get; set; }
        public DbSet<Household.Models.Room> Room { get; set; }
        public DbSet<Household.Models.ProductType> ProductType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductType>().HasData(
                new ProductType()
                {
                    Id = 1,
                    Name = "Small Kitchen Appliances"
                },

                new ProductType()
                {
                    Id = 2,
                    Name = "Large Kitchen Appliances"
                },
                 new ProductType()
                 {
                     Id = 3,
                     Name = "Electronics"
                 },
                  new ProductType()
                  {
                      Id = 4,
                      Name = "Utilies"
                  }


                );
        }
    }
}
