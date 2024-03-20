//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort And Peace
//==================================================

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using ProjectSimple.Api.Models.Foundations.Products;

namespace ProjectSimple.Api.Brokers.Storages
{
    public partial class StorageBroker:IStorageBroker
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(a => a.Id);
            modelBuilder.Entity<Product>().Property(b => b.Name).HasMaxLength(255);
        }
        public async ValueTask<Product> InsertProductAsync(Product product)
        {
            return await InsertAsync(product);
        }

      
        public IQueryable<Product> SelectAllProducts()
        {
            return SelectAll<Product>();
        }

        public async ValueTask<Product> SelectProductByIdAsync(Guid id)
        {
            return await SelectAsync<Product>(id);
        }

        public async ValueTask<Product> UpdateProductAsync(Product product)
        {
            return await UpdateAsync(product);
        }

        public async ValueTask<Product> DeleteProductAsync(Product product)
        {
           return await DeleteAsync(product);
        }
    }
}
