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

        //ApplicationUser user = new ApplicationUser
        //{
        //    FirstName = "Bill",
        //    LastName = "Smith",
        //    Email = "BillSmith@email.com"
        //}
    }
}
