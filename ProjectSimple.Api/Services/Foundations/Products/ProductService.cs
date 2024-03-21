//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort And Peace
//==================================================

using ProjectSimple.Api.Brokers.Loggings;
using ProjectSimple.Api.Brokers.Storages;
using ProjectSimple.Api.Models.Foundations.Products;
using ProjectSimple.Api.Models.Foundations.Products.Exceptions;

namespace ProjectSimple.Api.Services.Foundations.Products
{
    public class ProductService : IProductService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public ProductService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Product> AddProductAsync(Product product)
        {
            try
            {
                if (product is null)
                {
                    throw new NullProductException();
                }
                return this.storageBroker.InsertProductAsync(product);
            }
            catch (NullProductException nullProductException)
            {
                var productValidationException =
                    new ProductValidationException(nullProductException);

                this.loggingBroker.LogError(productValidationException);

                throw productValidationException;
            }
           
        }

        public IQueryable<Product> RetrieveAllProducts()
        {
            return this.storageBroker.SelectAllProducts();
        }

        public ValueTask<Product> RetrieveProductByIdAsync(Guid id)
        {
            return this.storageBroker.SelectProductByIdAsync(id);
        }

        public ValueTask<Product> ModifyProductAsync(Product product)
        {
            return this.storageBroker.UpdateProductAsync(product);
        }

        public ValueTask<Product> RemoveProductAsync(Product product)
        {
            return this.storageBroker.DeleteProductAsync(product);
        }
    }
}
