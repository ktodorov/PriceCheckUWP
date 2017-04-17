using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCheck.Data.Entities
{
    public class PriceChange : EntityBase
    {
        public double OldPrice { get; set; }

        public double NewPrice { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
