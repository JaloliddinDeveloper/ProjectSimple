//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort And Peace
//==================================================

using Moq;
using ProjectSimple.Api.Models.Foundations.Products;
using ProjectSimple.Api.Models.Foundations.Products.Exceptions;

namespace SimpleProject.Api.Unit.Tests.Services.Foundation.Products
{
    public partial class ProductServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfProductIsNullAndLogItAsync()
        {
            //given
            Product nullProduct = null;
            var nullProductException = new NullProductException();

            var expectedProductValidationException =
                new ProductValidationException(nullProductException);

            //when
            ValueTask<Product> addProductTask =
                this.productService.AddProductAsync(nullProduct);

            //then
            await Assert.ThrowsAsync<ProductValidationException>(() =>
            addProductTask.AsTask());


            this.loggingBrokerMock.Verify(broker =>
           broker.LogError(It.Is(SameExceptionAs(expectedProductValidationException))),
                Times.Once);

            this.storageBrokerMock.Verify(broker=>
            broker.InsertProductAsync(It.IsAny<Product>()),
            Times.Never);    


            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }


    }
}

