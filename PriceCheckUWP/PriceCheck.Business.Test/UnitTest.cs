
using PriceCheck.Business.Configuration;
using PriceCheck.Business.Services;
using PriceCheck.Business.Services.Query;
using System;
using Xunit;

namespace PriceCheck.Business.Test
{
    public class UnitTest1
    {
        [Fact]
        public async void TestMethod1()
        {
            DatabaseConfiguration.AddMigrations();
            AutoMapperConfiguration.Configure();

            var productService = new ProductQueryService();
            var products = await productService.GetAllProductsAsync();

            Assert.Equal(1, 1);
        }
    }
}
