//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort And Peace
//==================================================

using ProjectSimple.Api.Models.Foundations.Products;

namespace ProjectSimple.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Product> InsertProductAsync(Product product);
       // IQueryable<Product> SelectAllProducts();
       // ValueTask<Product> SelectProductByIdAsync(Guid id);
       // ValueTask<Product> UpdateProductAsync(Product product);
       // ValueTask<Product> DeleteProductAsync(Product product);
    }
}
