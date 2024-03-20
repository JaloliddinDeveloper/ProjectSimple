//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort And Peace
//==================================================

using Moq;
using ProjectSimple.Api.Brokers.Loggings;
using ProjectSimple.Api.Brokers.Storages;
using ProjectSimple.Api.Models.Foundations.Products;
using ProjectSimple.Api.Services.Foundations.Products;
using Tynamix.ObjectFiller;

namespace SimpleProject.Api.Unit.Tests.Services.Foundation.Products
{
    public partial class ProductServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IProductService productService;

        public ProductServiceTests()
        {
            this.storageBrokerMock=new Mock<IStorageBroker>();
            this.loggingBrokerMock=new Mock<ILoggingBroker>();

            this.productService = new ProductService
                (storageBroker:this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);

        }
        private static Product CreateRandomProduct() =>
           CreateProductFiller(data: GetRandomDateTimeOffset()).Create();
        public static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Filler<Product> CreateProductFiller(DateTimeOffset data)
        {
            var filler = new Filler<Product>();
            filler.Setup()
               .OnType<DateTimeOffset>().Use(data);
            return filler;
        }

    }
}
