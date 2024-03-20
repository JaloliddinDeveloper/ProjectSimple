//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort And Peace
//==================================================

using Force.DeepCloner;
using Moq;
using ProjectSimple.Api.Models.Foundations.Products;

namespace SimpleProject.Api.Unit.Tests.Services.Foundation.Products
{
    public partial class ProductServiceTests
    {
        [Fact]
        public async Task ShouldAddProductAsync()
        {
            //given
            Product randomProduct=CreateRandomProduct();
            Product inputProduct = randomProduct;
            Product returningProduct=inputProduct;
            Product expectedProduct= returningProduct.DeepClone();

            this.storageBrokerMock.Setup(broker=>
            broker.InsertProductAsync(inputProduct))
                .ReturnsAsync(returningProduct);

            //when
            Product actualProduct=await this.productService.AddProductAsync(inputProduct);

            //then
            this.storageBrokerMock.Verify(broker=>
            broker.InsertProductAsync(inputProduct), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
