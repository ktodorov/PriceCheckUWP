using PriceCheck.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCheck.DAL.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public Website Website { get; set; }

        public string Description { get; set; }

        public List<PriceChange> PriceChanges { get; set; }
    }
}
