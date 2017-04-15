using PriceCheck.Business.Interfaces.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCheck.Domain.Models;
using PriceCheck.Data.Context;
using AutoMapper;
using PriceCheck.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace PriceCheck.Business.Services.Command
{
    public class ProductCommandService : IProductCommandService
    {
        public async Task<int> AddProductAsync(ProductModel product)
        {
            var productEntity = Mapper.Map<Product>(product);
            using (var priceCheckContext = new PriceCheckContext())
            {
                await priceCheckContext.AddAsync(productEntity);
                await priceCheckContext.SaveChangesAsync();
            }

            return productEntity.Id;
        }

        public async Task DeleteProductAsync(ProductModel product)
        {
            var productEntity = Mapper.Map<Product>(product);
            using (var priceCheckContext = new PriceCheckContext())
            {
                priceCheckContext.Products.Remove(productEntity);
                await priceCheckContext.SaveChangesAsync();
            }
        }

        public async Task UpdateProductAsync(ProductModel product)
        {
            var productEntity = Mapper.Map<Product>(product);
            using (var priceCheckContext = new PriceCheckContext())
            {
                priceCheckContext.Products.Attach(productEntity);
                priceCheckContext.Entry(productEntity).State = EntityState.Modified;
                await priceCheckContext.SaveChangesAsync();
            }
        }
    }
}
