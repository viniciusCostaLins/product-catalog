using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data.Maps;
using ProductCatalog.Models;

namespace ProductCatalog.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; } 
        public DbSet<Category> Categories { get; set; }   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"Data Source=WIN-I7L2JKP99M\SQLEXPRESS;Initial Catalog=prodCatDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
        }
          
    }
}