using Microsoft.EntityFrameworkCore;
using ProcessingApp.Data;
using ProcessingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessingAppTest
{
    public static class EntityExtensions
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
    public class MockDb
    {
        public static ApplicationDbContext CreateMockDb()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().
                UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.PropertyCreateViewModel.Add(new PropertyModel { PropertyId = 1, PropertyName = "Test", 
                    PropertyAdress = "140 Bell Farm Rd",
                    PropertyPrice = 140,
                    City = "Barrie"
                });
                context.SaveChanges();
            }
            return new ApplicationDbContext(options);
        }
    }
}
