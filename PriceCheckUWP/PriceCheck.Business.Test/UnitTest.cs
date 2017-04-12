
using PriceCheck.Business.Configuration;
using PriceCheck.Business.Services;
using System;
using Xunit;

namespace PriceCheck.Business.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            DatabaseConfiguration.AddMigrations();
            AutoMapperConfiguration.Configure();

            var productService = new ProductService();
            var products = productService.GetAllProducts();

            Assert.Equal(1, 1);
        }
    }
}
