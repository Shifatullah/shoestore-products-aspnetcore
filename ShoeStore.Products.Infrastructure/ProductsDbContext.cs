using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoeStore.Products.Domain;

namespace ShoeStore.Products.Infrastructure
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(){
        }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("ssp");

            modelBuilder.Entity<CatalogueProduct>()
                .HasOne(cp => cp.Catalogue)
                .WithMany(c => c.CatalogueProducts)
                .HasForeignKey(cp => cp.CatalogueId);

            modelBuilder.Entity<CatalogueProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.CatalogueProducts)
                .HasForeignKey(cp => cp.ProductId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .Build();
                   optionsBuilder.UseSqlServer("<con srting>");                
            }
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Catalogue> Catalogues { get; set; }

        public DbSet<CatalogueProduct> CatalogueProducts { get; set; }
    }
}
