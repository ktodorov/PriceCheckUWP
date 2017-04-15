using PriceCheck.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCheck.Business.Interfaces.Command
{
    public interface IProductCommandService
    {
        Task<int> AddProductAsync(ProductModel product);

        Task UpdateProductAsync(ProductModel product);

        Task DeleteProductAsync(ProductModel product);
    }
}
