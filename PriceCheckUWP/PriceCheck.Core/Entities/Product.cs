using PriceCheck.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCheck.Core.Entities
{
    public class Product : EntityBase
    {
        public string Url { get; set; }

        public Website Website { get; set; }

        public List<PriceChange> PriceChanges { get; set; }
    }
}
