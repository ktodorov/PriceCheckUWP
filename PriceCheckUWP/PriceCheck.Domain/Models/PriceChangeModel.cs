using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PriceCheck.Domain.Models
{
    public class PriceChangeModel : ModelBase, INotifyPropertyChanged
    {
        private double oldPrice;
        public double OldPrice
        {
            get
            {
                return oldPrice;
            }
            set
            {
                if (oldPrice != value)
                {
                    oldPrice = value;
                    OnPropertyChanged(nameof(OldPrice));
                }
            }
        }

        private double newPrice;
        public double NewPrice
        {
            get
            {
                return newPrice;
            }
            set
            {
                if (newPrice != value)
                {
                    newPrice = value;
                    OnPropertyChanged(nameof(NewPrice));
                }
            }
        }

        private int productId;
        public int ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                if (productId != value)
                {
                    productId = value;
                    OnPropertyChanged(nameof(ProductId));
                }
            }
        }

        public ProductModel Product { get; set; }
    }
}
