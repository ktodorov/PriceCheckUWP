using AutoMapper;
using PriceCheck.Data.Entities;
using PriceCheck.Data.Enums;
using PriceCheck.Domain.Enums;
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
                config.CreateMap<Product, ProductModel>().ForMember(dest => dest.Website, opt => opt.MapFrom(x => (WebsiteModel)(int)x.Website));
                config.CreateMap<ProductModel, Product>().ForMember(dest => dest.Website, opt => opt.MapFrom(x => (Website)(int)x.Website));
                config.CreateMap<PriceChange, PriceChangeModel>().ForMember(dest => dest.Product, opt => opt.Ignore());
                config.CreateMap<PriceChangeModel, PriceChange>();
            });
        }
    }
}
