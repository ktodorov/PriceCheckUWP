using PriceCheck.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCheck.Domain.Models
{
    public class ProductModel : ModelBase, INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string url;
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                if (url != value)
                {
                    url = value;
                    OnPropertyChanged(nameof(Url));
                }
            }
        }

        private WebsiteModel website;
        public WebsiteModel Website
        {
            get
            {
                return website;
            }
            set
            {
                if (website != value)
                {
                    website = value;
                    OnPropertyChanged(nameof(Website));
                }
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public List<PriceChangeModel> PriceChanges { get; set; }
    }
}
