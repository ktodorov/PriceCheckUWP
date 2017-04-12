using AutoMapper;
using PriceCheck.Data.Entities;
using PriceCheck.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCheck.Business.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Product, ProductModel>();
                config.CreateMap<PriceChange, PriceChangeModel>();
            });
        }
    }
}
