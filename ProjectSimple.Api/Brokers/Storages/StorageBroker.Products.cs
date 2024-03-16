//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort And Peace
//==================================================

using Microsoft.EntityFrameworkCore;
using ProjectSimple.Api.Models.Foundations.Products;

namespace ProjectSimple.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(a => a.Id);
            modelBuilder.Entity<Product>().Property(b => b.Name).HasMaxLength(255);
        }

        public async ValueTask<Product> InsertProductAsync(Product product) =>
            await InsertAsync(product);

        public IQueryable<Product> SelectAllproducts() =>
            SelectAll<Product>();

        public async ValueTask<Product> SelectproductByIdAsync(Guid id) =>
            await SelectAsync<Product>(id);

        public async ValueTask<Product> UpdateproductAsync(Product product) =>
            await UpdateAsync(product);

        public async ValueTask<Product> DeleteproductAsync(Product product) =>
            await DeleteAsync(product);
    }
}
