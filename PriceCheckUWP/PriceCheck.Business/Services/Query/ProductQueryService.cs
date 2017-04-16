using PriceCheck.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCheck.Domain.Models;
using PriceCheck.Data.Context;
using AutoMapper;
using PriceCheck.Data.Entities;
using PriceCheck.Business.Interfaces.Query;
using Microsoft.EntityFrameworkCore;

namespace PriceCheck.Business.Services.Query
{
    public class ProductQueryService : IProductQueryService
    {
        public async Task<List<PriceChangeModel>> GetAllPriceChangesAsync()
        {
            using (var priceCheckContext = new PriceCheckContext())
            {
                var priceChanges = await priceCheckContext.Products.ToListAsync();
                var priceChangeModels = Mapper.Map<List<PriceChangeModel>>(priceChanges);
                return priceChangeModels;
            }
        }

        public async Task<List<ProductModel>> GetAllProductsAsync(string searchText)
        {
            using (var priceCheckContext = new PriceCheckContext())
            {
                var productsQuery = priceCheckContext.Products.AsQueryable();

                if (!string.IsNullOrEmpty(searchText))
                {
                    var loweredSearchText = searchText.ToLower();
                    productsQuery = productsQuery.Where(p => p.Name.ToLower().Contains(loweredSearchText));
                }

                var products = await productsQuery.ToListAsync();
                var productModels = Mapper.Map<List<ProductModel>>(products);
                return productModels;
            }
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            using (var priceCheckContext = new PriceCheckContext())
            {
                var product = await priceCheckContext.Products.FirstOrDefaultAsync(p => p.Id == id);
                var productModel = Mapper.Map<ProductModel>(product);
                return productModel;
            }
        }
    }
}
