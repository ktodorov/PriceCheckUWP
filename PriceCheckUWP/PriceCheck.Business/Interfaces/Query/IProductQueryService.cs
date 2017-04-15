using PriceCheck.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCheck.Business.Interfaces.Query
{
    public interface IProductQueryService
    {
        Task<List<PriceChangeModel>> GetAllPriceChangesAsync();

        Task<List<ProductModel>> GetAllProductsAsync();

        Task<ProductModel> GetProductById(int id);
    }
}
