using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProcessingApp.Models;
using ProcessingApp.ViewModels;

namespace ProcessingApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<ProcessingApp.Models.OwnerModel> OwnerModel { get; set; }
        public DbSet<ProcessingApp.Models.PropertyModel> PropertyCreateViewModel { get; set; }
        public DbSet<ProcessingApp.Models.MyApplication> MyApplication { get; set; }
        // seed the data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OwnerModel>().HasData(
                new OwnerModel() { OwnerId = 3, OwnerName = "LLC Test"},
                new OwnerModel() { OwnerId = 4, OwnerName = "Barsukov&Co" }
                );
            modelBuilder.Entity<PropertyModel>().HasData(
                new { PropertyId = 12, PropertyName = "SeededHome", PropertyAdress = "SeedDrive", PropertyPrice = 95.5, City = "Seed", ImageUrl = "" }
            );
        }
        // seed the data

        public DbSet<ProcessingApp.Models.ApplicationRole> ApplicationRole { get; set; }
    }
}
