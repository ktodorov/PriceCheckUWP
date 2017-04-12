using PriceCheck.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCheck.Domain.Models;
using PriceCheck.Data.Context;
using AutoMapper;

namespace PriceCheck.Business.Services
{
    public class ProductService : IProductService
    {
        public List<PriceChangeModel> GetAllPriceChanges()
        {
            using (var priceCheckContext = new PriceCheckContext())
            {
                var priceChanges = priceCheckContext.Products.ToList();
                var priceChangeModels = Mapper.Map<List<PriceChangeModel>>(priceChanges);
                return priceChangeModels;
            }
        }

        public List<ProductModel> GetAllProducts()
        {
            using (var priceCheckContext = new PriceCheckContext())
            {
                var products = priceCheckContext.Products.ToList();
                var productModels = Mapper.Map<List<ProductModel>>(products);
                return productModels;
            }
        }
    }
}
