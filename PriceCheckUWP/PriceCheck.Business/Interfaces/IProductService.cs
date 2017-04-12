using PriceCheck.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCheck.Business.Interfaces
{
    interface IProductService
    {
        List<PriceChangeModel> GetAllPriceChanges();

        List<ProductModel> GetAllProducts();
    }
}
